using Azure.Storage.Blobs;
using HGV.Basilius;
using HGV.Basilius.Client;
using HGV.Euls.Server.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Polly;
using Polly.Caching;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HGV.Euls.Server
{
    using Pair = Tuple<Bitmap, List<Tuple<Bitmap, bool>>>;

    public class DrawFunction
    {
        private readonly Size size;
        private readonly HttpClient httpClient;
        private readonly IReadOnlyDictionary<int, Hero> heroes;
        private readonly IReadOnlyDictionary<string, Ability> abilities;
        private readonly IAsyncCacheProvider cacheProvider;

        public DrawFunction(IHttpClientFactory httpClientFactory, IAsyncCacheProvider cacheProvider, IMetaClient metaClient)
        {
            this.httpClient = httpClientFactory.CreateClient();
            this.cacheProvider = cacheProvider;
            this.size = new Size(64, 64);
            this.heroes = metaClient.GetHeroes().ToDictionary(_ => _.Id, _ => _);
            this.abilities = metaClient.GetAbilities().ToDictionary(_ => _.Key, _ => _);
        }

        [FunctionName("Draw")]
        public async Task Draw(
            [QueueTrigger("events")] Root root,
            [Blob("drafts/radiant-{token}.png", FileAccess.ReadWrite)] BlobClient radiant,
            [Blob("drafts/dire-{token}.png", FileAccess.ReadWrite)] BlobClient dire,
            ILogger log
        )
        {
            try
            {
                var t1 = DrawOverlayRadiantImages(root, radiant);
                var t2 = DrawOverlayDireImages(root, dire);
                await Task.WhenAll(t1, t2);
            }
            catch(Exception ex)
            {
                log.LogError(ex, ex.Message);
            }
        }

        private async Task DrawOverlayRadiantImages(Root root, BlobClient client)
        {
            var heroes = new List<Pair>();
            heroes.Add(await GetPlayer(root.Heroes.Radiant.Player0, root.Abilities.Radiant.Player0));
            heroes.Add(await GetPlayer(root.Heroes.Radiant.Player1, root.Abilities.Radiant.Player1));
            heroes.Add(await GetPlayer(root.Heroes.Radiant.Player2, root.Abilities.Radiant.Player2));
            heroes.Add(await GetPlayer(root.Heroes.Radiant.Player3, root.Abilities.Radiant.Player3));
            heroes.Add(await GetPlayer(root.Heroes.Radiant.Player4, root.Abilities.Radiant.Player4));
            await DrawCard(client, heroes);
        }

        private async Task DrawOverlayDireImages(Root root, BlobClient client)
        {
            var heroes = new List<Pair>();
            heroes.Add(await GetPlayer(root.Heroes.Dire.Player5, root.Abilities.Dire.Player5));
            heroes.Add(await GetPlayer(root.Heroes.Dire.Player6, root.Abilities.Dire.Player6));
            heroes.Add(await GetPlayer(root.Heroes.Dire.Player7, root.Abilities.Dire.Player7));
            heroes.Add(await GetPlayer(root.Heroes.Dire.Player8, root.Abilities.Dire.Player8));
            heroes.Add(await GetPlayer(root.Heroes.Dire.Player9, root.Abilities.Dire.Player9));
            await DrawCard(client, heroes);
        }

        private async Task DrawCard(BlobClient client, List<Pair> heroes)
        {
            SolidBrush brush = new SolidBrush(Color.FromArgb(150, Color.Black));

            using var bitmap = new Bitmap(500, 350);
            using (var g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.Transparent);

                try
                {
                    var max = heroes.Max(_ => _.Item2.Count);
                    var offset = 500 - ((max * this.size.Width) + max + this.size.Width);
                    var y = 1;
                    foreach (var pair in heroes)
                    {
                        var x = offset;

                        if(pair.Item1 is not null)
                        {
                            g.DrawImage(pair.Item1, new Rectangle(new Point(x, y), size));
                        }
                        
                        x += size.Width + 1;

                        foreach (var ability in pair.Item2)
                        {
                            var rect = new Rectangle(new Point(x, y), size);
                            g.DrawImage(ability.Item1, rect);

                            if (ability.Item2 == false)
                            {
                                g.FillRectangle(brush, rect);
                            }

                            x += size.Width + 1;
                        }

                        y += size.Height + 1;
                    }
                }
                catch (Exception ex)
                {
                }
            }

            var ms = new MemoryStream();
            bitmap.Save(ms, ImageFormat.Png);
            ms.Seek(0, SeekOrigin.Begin);
            await client.UploadAsync(ms, true);
        }

        private async Task<Pair> GetPlayer(HeroPlayer ph, AbilitiesPlayer pa)
        {
            var hid = ph?.Id ?? 0;
            this.heroes.TryGetValue(hid, out Hero hero);
            var heroImage = await GetCachedImage(hero?.ImageIcon ?? String.Empty);

            var a1 = pa?.Ability0;
            var a2 = pa?.Ability1;
            var a3 = pa?.Ability2;
            var a4 = pa?.Ability3;
            var a5 = pa?.Ability4;
            var a6 = pa?.Ability5;

            var abilities = new List<Tuple<Bitmap, bool>>();
            if(this.abilities.TryGetValue(a1?.Name ?? String.Empty, out Ability v1))
            {
                var img = await GetCachedImage(v1.Image);
                if(img is not null)
                {
                    abilities.Add(Tuple.Create(img, a1.Level > 0));
                }
            }
                

            if (this.abilities.TryGetValue(a2?.Name ?? String.Empty, out Ability v2))
            {
                var img = await GetCachedImage(v2.Image);
                if (img is not null)
                {
                    abilities.Add(Tuple.Create(img, a2.Level > 0));
                }
            }
                

            if (this.abilities.TryGetValue(a3?.Name ?? String.Empty, out Ability v3))
            {
                var img = await GetCachedImage(v3.Image);
                if (img is not null)
                {
                    abilities.Add(Tuple.Create(img, a3.Level > 0));
                }
            }

            if (this.abilities.TryGetValue(a4?.Name ?? String.Empty, out Ability v4))
            {
                var img = await GetCachedImage(v4.Image);
                if (img is not null)
                {
                    abilities.Add(Tuple.Create(img, a4.Level > 0));
                }
            }

            if (this.abilities.TryGetValue(a5?.Name ?? String.Empty, out Ability v5))
            {
                var img = await GetCachedImage(v5.Image);
                if (img is not null)
                {
                    abilities.Add(Tuple.Create(img, a5.Level > 0));
                }
            }

            if (this.abilities.TryGetValue(a6?.Name ?? String.Empty, out Ability v6))
            {
                var img = await GetCachedImage(v6.Image);
                if (img is not null)
                {
                    abilities.Add(Tuple.Create(img, a6.Level > 0));
                }
            }

            return Tuple.Create(heroImage, abilities);
        }

        private async Task<Bitmap> GetCachedImage(string url)
        {
            var cache = Policy.CacheAsync<Bitmap>(this.cacheProvider, TimeSpan.FromMinutes(60));
            var fallback = Policy<Bitmap>.Handle<Exception>().FallbackAsync<Bitmap>(default(Bitmap));
            var wrap = Policy.WrapAsync(fallback, cache);

            var ctx = new Context(url);
            var result = await wrap.ExecuteAsync(async (_) =>
            {
                var data = await httpClient.GetByteArrayAsync(url);
                using var ms = new MemoryStream(data);
                return new Bitmap(ms);
            }, ctx);

            return result;
        }
    }
}
