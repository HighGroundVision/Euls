using HGV.Basilius;
using HGV.Basilius.Client;
using HGV.Euls.Server.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Polly;
using Polly.Registry;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HGV.Euls.Server
{
    public class DrawFunction
    {
        private readonly HttpClient httpClient;
        private IReadOnlyDictionary<int, Hero> heroes;
        private IReadOnlyDictionary<string, Ability> abilities;
        private IAsyncPolicy<byte[]> cachePolicy;

        public DrawFunction(IHttpClientFactory httpClientFactory, IReadOnlyPolicyRegistry<string> policyRegistry, IMetaClient metaClient)
        {
            this.httpClient = httpClientFactory.CreateClient();
            this.cachePolicy = policyRegistry.Get<IAsyncPolicy<byte[]>>("Hyperstone");

            this.heroes = metaClient.GetHeroes().ToDictionary(_ => _.Id, _ => _);
            this.abilities = metaClient.GetAbilities().ToDictionary(_ => _.Key, _ => _);
        }

        [FunctionName("Draw")]
        public async Task Draw(
            [QueueTrigger("events")] Root root,
            [Blob("drafts/{token}.png", FileAccess.Write)] Stream stream,
            ILogger log
        )
        {
            try
            {
                await DrawOverlayImage(root, stream);
            }
            catch(Exception ex)
            {
                log.LogError(ex, ex.Message);
            }
        }

        private async Task DrawOverlayImage(Root root, Stream stream)
        {
            var heroes = new List<int>()
            {
                root.Heroes.Radiant.Player0.Id.GetValueOrDefault(),
                root.Heroes.Radiant.Player1.Id.GetValueOrDefault(),
                root.Heroes.Radiant.Player2.Id.GetValueOrDefault(),
                root.Heroes.Radiant.Player3.Id.GetValueOrDefault(),
                root.Heroes.Radiant.Player4.Id.GetValueOrDefault(),
                root.Heroes.Dire.Player5.Id.GetValueOrDefault(),
                root.Heroes.Dire.Player6.Id.GetValueOrDefault(),
                root.Heroes.Dire.Player7.Id.GetValueOrDefault(),
                root.Heroes.Dire.Player8.Id.GetValueOrDefault(),
                root.Heroes.Dire.Player9.Id.GetValueOrDefault(),
            }
            .Join(this.heroes, id => id, _ => _.Key, (lhs, rhs) => rhs.Value)
            .ToList();

            var upgrades = new List<(bool, bool)>()
            {
                (root.Heroes.Radiant.Player0.AghanimsScepter.GetValueOrDefault(), root.Heroes.Radiant.Player0.AghanimsShard.GetValueOrDefault()),
                (root.Heroes.Radiant.Player1.AghanimsScepter.GetValueOrDefault(), root.Heroes.Radiant.Player1.AghanimsShard.GetValueOrDefault()),
                (root.Heroes.Radiant.Player2.AghanimsScepter.GetValueOrDefault(), root.Heroes.Radiant.Player2.AghanimsShard.GetValueOrDefault()),
                (root.Heroes.Radiant.Player3.AghanimsScepter.GetValueOrDefault(), root.Heroes.Radiant.Player3.AghanimsShard.GetValueOrDefault()),
                (root.Heroes.Radiant.Player4.AghanimsScepter.GetValueOrDefault(), root.Heroes.Radiant.Player4.AghanimsShard.GetValueOrDefault()),
                (root.Heroes.Dire.Player5.AghanimsScepter.GetValueOrDefault(), root.Heroes.Dire.Player5.AghanimsShard.GetValueOrDefault()),
                (root.Heroes.Dire.Player6.AghanimsScepter.GetValueOrDefault(), root.Heroes.Dire.Player6.AghanimsShard.GetValueOrDefault()),
                (root.Heroes.Dire.Player7.AghanimsScepter.GetValueOrDefault(), root.Heroes.Dire.Player7.AghanimsShard.GetValueOrDefault()),
                (root.Heroes.Dire.Player8.AghanimsScepter.GetValueOrDefault(), root.Heroes.Dire.Player8.AghanimsShard.GetValueOrDefault()),
                (root.Heroes.Dire.Player9.AghanimsScepter.GetValueOrDefault(), root.Heroes.Dire.Player9.AghanimsShard.GetValueOrDefault()),
            };

            var collection = new List<List<AbilityInfo>>()
            {
                new List<AbilityInfo>()
                {
                    root.Abilities.Radiant.Player0.Ability0,
                    root.Abilities.Radiant.Player0.Ability1,
                    root.Abilities.Radiant.Player0.Ability2,
                    root.Abilities.Radiant.Player0.Ability3,
                    root.Abilities.Radiant.Player0.Ability4,
                    root.Abilities.Radiant.Player0.Ability5,
                },
                new List<AbilityInfo>()
                {
                    root.Abilities.Radiant.Player1.Ability0,
                    root.Abilities.Radiant.Player1.Ability1,
                    root.Abilities.Radiant.Player1.Ability2,
                    root.Abilities.Radiant.Player1.Ability3,
                    root.Abilities.Radiant.Player1.Ability4,
                    root.Abilities.Radiant.Player1.Ability5,
                },
                new List<AbilityInfo>()
                {
                    root.Abilities.Radiant.Player2.Ability0,
                    root.Abilities.Radiant.Player2.Ability1,
                    root.Abilities.Radiant.Player2.Ability2,
                    root.Abilities.Radiant.Player2.Ability3,
                    root.Abilities.Radiant.Player2.Ability4,
                    root.Abilities.Radiant.Player2.Ability5,
                },
                new List<AbilityInfo>()
                {
                    root.Abilities.Radiant.Player3.Ability0,
                    root.Abilities.Radiant.Player3.Ability1,
                    root.Abilities.Radiant.Player3.Ability2,
                    root.Abilities.Radiant.Player3.Ability3,
                    root.Abilities.Radiant.Player3.Ability4,
                    root.Abilities.Radiant.Player3.Ability5,
                },
                new List<AbilityInfo>()
                {
                    root.Abilities.Radiant.Player4.Ability0,
                    root.Abilities.Radiant.Player4.Ability1,
                    root.Abilities.Radiant.Player4.Ability2,
                    root.Abilities.Radiant.Player4.Ability3,
                    root.Abilities.Radiant.Player4.Ability4,
                    root.Abilities.Radiant.Player4.Ability5,
                },
                new List<AbilityInfo>()
                {
                    root.Abilities.Dire.Player5.Ability0,
                    root.Abilities.Dire.Player5.Ability1,
                    root.Abilities.Dire.Player5.Ability2,
                    root.Abilities.Dire.Player5.Ability3,
                    root.Abilities.Dire.Player5.Ability4,
                    root.Abilities.Dire.Player5.Ability5,
                },
                new List<AbilityInfo>()
                {
                    root.Abilities.Dire.Player6.Ability0,
                    root.Abilities.Dire.Player6.Ability1,
                    root.Abilities.Dire.Player6.Ability2,
                    root.Abilities.Dire.Player6.Ability3,
                    root.Abilities.Dire.Player6.Ability4,
                    root.Abilities.Dire.Player6.Ability5,
                },
                new List<AbilityInfo>()
                {
                    root.Abilities.Dire.Player7.Ability0,
                    root.Abilities.Dire.Player7.Ability1,
                    root.Abilities.Dire.Player7.Ability2,
                    root.Abilities.Dire.Player7.Ability3,
                    root.Abilities.Dire.Player7.Ability4,
                    root.Abilities.Dire.Player7.Ability5,
                },
                new List<AbilityInfo>()
                {
                    root.Abilities.Dire.Player8.Ability0,
                    root.Abilities.Dire.Player8.Ability1,
                    root.Abilities.Dire.Player8.Ability2,
                    root.Abilities.Dire.Player8.Ability3,
                    root.Abilities.Dire.Player8.Ability4,
                    root.Abilities.Dire.Player8.Ability5,
                },
                new List<AbilityInfo>()
                {
                    root.Abilities.Dire.Player9.Ability0,
                    root.Abilities.Dire.Player9.Ability1,
                    root.Abilities.Dire.Player9.Ability2,
                    root.Abilities.Dire.Player9.Ability3,
                    root.Abilities.Dire.Player9.Ability4,
                    root.Abilities.Dire.Player9.Ability5,
                }
            };

            var denyList = new List<int>() { 8034, 8035 };

            var abilities = new Dictionary<int, List<Ability>>();
            for (int i = 0; i < collection.Count; i++)
            {
                var list = collection[i]
                    .Join(this.abilities, _ => _.Name, _ => _.Key, (lhs, rhs) => rhs.Value)
                    .Where(_ => denyList.Contains(_.Id) == false)
                    .Where(_ => _.IsGrantedByScepter == false)
                    .Where(_ => _.IsGrantedByShard == false)
                    .OrderBy(_ => _.IsUltimate)
                    .ToList();

                abilities.Add(i, list);
            }

            (Bitmap both, Bitmap shard, Bitmap scepter) = await GetUpgradesOverlays();

            using var b1 = new SolidBrush(Color.FromArgb(255, 18, 133, 41));
            using var b1a = new SolidBrush(Color.FromArgb(90, 18, 133, 41));
            using var b2 = new SolidBrush(Color.FromArgb(255, 167, 50, 47));
            using var b2a = new SolidBrush(Color.FromArgb(90, 167, 50, 47));

            using var bitmap = new Bitmap(1920, 1080);
            using (var g = Graphics.FromImage(bitmap))
            {
                var sizeA = 64; // 32
                var sizeH = 0; // 54 // 108

                for (int i = 0; i < heroes.Count; i++)
                {
                    var top = i < 5 ? 150 : 260;
                    var url = heroes[i].ImageIcon;

                    var image = await GetCachedImage(url);

                    var dest = new Rectangle(1920 - (sizeA * 5) - 10, top + (2 * i) + (i * sizeA), sizeA, sizeA);
                    g.DrawImage(image, dest);
                }

                for (int p = 0; p < abilities.Count; p++)
                {
                    var list = abilities[p];
                    for (int a = 0; a < list.Count; a++)
                    {
                        var ability = list[a];
                        var image = await GetCachedImage(ability.Image);

                        var x = a;
                        var y = p;
                        var top = y < 5 ? 150 : 260;
                        var left = (1920 - sizeH) - (sizeA * 4) - (2 * 4);

                        var dest = new Rectangle(left + (x * sizeA) + (2 * x), top + (2 * y) + (y * sizeA), sizeA, sizeA); // 1721
                        g.DrawImage(image, dest);

                        var hasScepterUpgrade = ability.HasScepterUpgrade || ability.IsGrantedByScepter;
                        var hasShardUpgrade = ability.HasShardUpgrade || ability.IsGrantedByShard;
                        (bool hasScepter, bool hasShard) = upgrades[y];
                        if (hasScepterUpgrade && hasScepter && hasShardUpgrade && hasShard)
                            g.DrawImage(both, dest);
                        else if (hasScepterUpgrade && hasScepter)
                            g.DrawImage(scepter, dest);
                        else if (hasShardUpgrade && hasShard)
                            g.DrawImage(shard, dest);
                    }
                }
            }

            bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
        }

        private async Task<Bitmap> GetCachedImage(string url)
        {
            try
            {
                var ctx = new Context(url);

                var result = await this.cachePolicy.ExecuteAsync(async (_) =>
                {
                    var data = await httpClient.GetByteArrayAsync(url);
                    return data;
                }, ctx);

                using var ms = new MemoryStream(result);
                return new Bitmap(ms);
            }
            catch (Exception)
            {
                return new Bitmap(0, 0);
            }
        }

        private async Task<(Bitmap, Bitmap, Bitmap)> GetUpgradesOverlays()
        {
            var both = await GetCachedImage("https://hyperstone.highgroundvision.com/images/aghs/aghs_both.png");
            var shard = await GetCachedImage("https://hyperstone.highgroundvision.com/images/aghs/aghs_shard.png");
            var scepter = await GetCachedImage("https://hyperstone.highgroundvision.com/images/aghs/aghs_scepter.png");
            return (both, shard, scepter);
        }
    }
}
