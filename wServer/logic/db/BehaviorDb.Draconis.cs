using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;
using wServer.logic.behaviors;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ LairOfDraconis = () => Behav()
            .Init("NM Black Dragon God",
                new State(
                    new Shoot(10, projectileIndex: 1, coolDown: 1000)
                )
            )
        .Init("lod Ivory Wyvern",
            new State(
            new State("taunt",
                new ConditionalEffect(ConditionEffectIndex.Invulnerable),
               new TimedTransition(2000, "taunt1")
                ),

            new State("taunt1",
                new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                 new Taunt("Thank you adventurer you have freed the souls of the four dragons so that I may consume their powers."),
                 new TimedTransition(3000, "taunt2")
                ),

               new State("taunt2",
                   new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                new Taunt("I owe you much but I cannot let you leave. These walls will make a fine graveyard for your bones."),
                new TimedTransition(3000, "taunt3")
                   ),

                   new State("taunt3",
                       new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                 new Taunt("Behold the glory of my true powers!"),
                 new TimedTransition(3000, "minions")
                       ),
                new State("minions",
                    new Shoot(10, projectileIndex: 0, count: 1, shootAngle: 0, coolDown: 1500, coolDownOffset: 1500),
                    new Shoot(10, projectileIndex: 0, count: 1, shootAngle: 0, coolDown: 1300, coolDownOffset: 1500),
                    new Shoot(10, projectileIndex: 0, count: 1, shootAngle: 0, coolDown: 1100, coolDownOffset: 1500),
                    new Shoot(10, projectileIndex: 0, count: 1, shootAngle: 0, coolDown: 900, coolDownOffset: 1500),
                    new Shoot(10, projectileIndex: 0, count: 1, shootAngle: 0, coolDown: 700, coolDownOffset: 1500),
                    new Taunt("Run little hero, as fast as you can"),
                    new TossObject("lod Mirror Wyvern1", 4, 0, coolDown: 99999999, coolDownOffset: 0),
                    new TossObject("lod Mirror Wyvern2", 8, 0, coolDown: 99999999, coolDownOffset: 0),
                    new TossObject("lod Mirror Wyvern3", 4, 180, coolDown: 99999999, coolDownOffset: 0),
                    new TossObject("lod Mirror Wyvern4", 8, 180, coolDown: 99999999, coolDownOffset: 0),
                    new MoveTo(10, 0, 1),
                    new TimedTransition(6000, "minions1")
                ),
                new State("minions1",
                    new Shoot(10, projectileIndex: 0, count: 1, shootAngle: 0, coolDown: 1500, coolDownOffset: 1500),
                    new Shoot(10, projectileIndex: 0, count: 1, shootAngle: 0, coolDown: 1300, coolDownOffset: 1500),
                    new Shoot(10, projectileIndex: 0, count: 1, shootAngle: 0, coolDown: 1100, coolDownOffset: 1500),
                    new Shoot(10, projectileIndex: 0, count: 1, shootAngle: 0, coolDown: 900, coolDownOffset: 1500),
                    new Shoot(10, projectileIndex: 0, count: 1, shootAngle: 0, coolDown: 700, coolDownOffset: 1500),
                    new MoveTo(-20, 0, 1),
                    new TimedTransition(6000, "minions2")
                    ),
                new State("minions2",
                    new Shoot(10, projectileIndex: 0, count: 1, shootAngle: 0, coolDown: 1500, coolDownOffset: 1500),
                    new Shoot(10, projectileIndex: 0, count: 1, shootAngle: 0, coolDown: 1300, coolDownOffset: 1500),
                    new Shoot(10, projectileIndex: 0, count: 1, shootAngle: 0, coolDown: 1100, coolDownOffset: 1500),
                    new Shoot(10, projectileIndex: 0, count: 1, shootAngle: 0, coolDown: 900, coolDownOffset: 1500),
                    new Shoot(10, projectileIndex: 0, count: 1, shootAngle: 0, coolDown: 700, coolDownOffset: 1500),
                    new MoveTo(10, 0, 1),
                     new TimedTransition(8000, "blast")
                    ),
                new State("blast",
                    new Shoot(10, projectileIndex: 0, count: 12, shootAngle: 20, coolDown: 1500, coolDownOffset: 1500),
                    new Taunt("My magic can no longer sustain my mirrors, what have you done?!"),
                    new HpLessTransition(.50, "flames")
                    ),
                    new State("flames",
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                    new TossObject("lod Red Soul Flame", 4, 0, coolDown: 99999999, coolDownOffset: 0),
                    new TossObject("lod Black Soul Flame", 8, 0, coolDown: 99999999, coolDownOffset: 0),
                    new TossObject("lod Green Soul Flame", 4, 180, coolDown: 99999999, coolDownOffset: 0),
                    new TossObject("lod Blue Soul Flame", 8, 180, coolDown: 99999999, coolDownOffset: 0),
                    new TimedTransition(4000, "prerage")
                    ),
                    new State("prerage",
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                    new EntityNotExistsTransition("lod Black Soul Flame", 50, "rage")
                        ),

                    new State("rage",
                    new Taunt("So you wish to fight your fate? Alright then I will not hold back any longer."),
                    new MoveTo(0, 10, 1),
                    new TimedTransition(3000, "rage1")
                        ),
                new State("rage1",
                    new TossObject("lod White Dragon Orb", 10, 45, coolDown: 99999999, coolDownOffset: 0),
                    new TossObject("lod White Dragon Orb", 10, 135, coolDown: 99999999, coolDownOffset: 0),
                    new TossObject("lod White Dragon Orb", 10, 225, coolDown: 99999999, coolDownOffset: 0),
                    new TossObject("lod White Dragon Orb", 10, 315, coolDown: 99999999, coolDownOffset: 0),
                    new Shoot(10, projectileIndex: 1, count: 5, shootAngle: 18, fixedAngle: 0),
                    new Shoot(10, projectileIndex: 2, count: 5, shootAngle: 18, fixedAngle: 90),
                    new Shoot(10, projectileIndex: 3, count: 5, shootAngle: 18, fixedAngle: 180),
                    new Shoot(10, projectileIndex: 4, count: 5, shootAngle: 18, fixedAngle: 270),
                    new HpLessTransition(.20, "rage2")
                    ),
                new State("rage2",
                    new Shoot(10, projectileIndex: 0, count: 12, shootAngle: 20, coolDown: 1500, coolDownOffset: 1500),
                    new Follow(0.85, range: 1, coolDown: 0),
                    new HpLessTransition(.07, "death")
                    ),
                new State("death",
                new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                new ReturnToSpawn(speed: 1),
                new Taunt("You may have beaten me this time, but I will find a way to leave this place!  And on that day you will suffer greatly..."),
                new TimedTransition(5000, "death2")
                    ),
                new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                new State("death2",
                new Spawn("lod Ivory Loot", 1),
                new Decay(0)
                    )
        ))

                    .Init("lod Ivory Loot",
            new State(
            new State("appear",
                new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                new TimedTransition(5000, "death")
                ),
            new State("death",
                new Decay(1000000)
                )),
                    new Threshold(0.10,
                    new ItemLoot("Potion of Dexterity", 0.5),
                    new ItemLoot("Potion of Speed", 0.5),
                    new ItemLoot("Potion of Attack", 0.5),
                    new ItemLoot("Potion of Vitality", 0.5),
                    new ItemLoot("Potion of Defense", 0.5),
                    new ItemLoot("Midnight Star", 0.05),
                    new ItemLoot("Wine Cellar Incantation", 0.15),
                    new ItemLoot("Platinum Knight Skin", 0.03),
                    new TierLoot(13, ItemType.Armor, 0.03),
                    new TierLoot(12, ItemType.Weapon, 0.05),
                    new EggLoot(EggRarity.Common, 0.1),
                    new EggLoot(EggRarity.Uncommon, 0.05),
                    new EggLoot(EggRarity.Rare, 0.01),
                    new EggLoot(EggRarity.Legendary, 0.009)
                )
           )

            .Init("lod White Dragon Orb",
            new State(
            new State("attack",
                new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                new Shoot(10, projectileIndex: 0, count: 16, coolDown: 1500, coolDownOffset: 1000),
                new Shoot(10, projectileIndex: 1, count: 14, coolDown: 2000, coolDownOffset: 1000),
                new EntityNotExistsTransition("lod Ivory Wyvern", 50, "death")
                ),
                new State("death",
                    new Decay (0)
                    )
                ))

        .Init("lod Red Soul Flame",
            new State("attack",
                new Taunt("Look at my beautiful flames"),
                new Shoot(10, projectileIndex: 0, count: 8, shootAngle: 20, coolDown: 1500, coolDownOffset: 1000)
                ))

        .Init("lod Green Soul Flame",
            new State("attack",
                new Taunt("Look at my beautiful flames"),
                new Shoot(10, projectileIndex: 0, count: 8, shootAngle: 20, coolDown: 1500, coolDownOffset: 1000)
                ))

        .Init("lod Blue Soul Flame",
            new State("attack",
                new Taunt("Look at my beautiful flames"),
                new Shoot(10, projectileIndex: 0, count: 8, shootAngle: 20, coolDown: 1500, coolDownOffset: 1000)
                ))

        .Init("lod Black Soul Flame",
            new State("attack",
                new Taunt("Look at my beautiful flames"),
                new Shoot(10, projectileIndex: 0, count: 8, shootAngle: 20, coolDown: 1500, coolDownOffset: 1000)
                ))


        .Init("lod Mirror Wyvern1",
                new State(
                    new State("attack",
                    new Shoot(5, projectileIndex: 0, count: 1, shootAngle: 0, coolDown: 1500, coolDownOffset: 1500),
                    new Shoot(5, projectileIndex: 0, count: 1, shootAngle: 0, coolDown: 1300, coolDownOffset: 1500),
                    new Shoot(5, projectileIndex: 0, count: 1, shootAngle: 0, coolDown: 1100, coolDownOffset: 1500),
                    new Shoot(5, projectileIndex: 0, count: 1, shootAngle: 0, coolDown: 900, coolDownOffset: 1500),
                    new Shoot(5, projectileIndex: 0, count: 1, shootAngle: 0, coolDown: 700, coolDownOffset: 1500),
                    new TimedTransition(20000, "death")
                        ),
                    new State("death",
                        new Decay(0)
                        )
                ))
            
                .Init("lod Mirror Wyvern2",
                new State(
                    new State("attack",
                    new Shoot(5, projectileIndex: 0, count: 1, shootAngle: 0, coolDown: 1500, coolDownOffset: 1500),
                    new Shoot(5, projectileIndex: 0, count: 1, shootAngle: 0, coolDown: 1300, coolDownOffset: 1500),
                    new Shoot(5, projectileIndex: 0, count: 1, shootAngle: 0, coolDown: 1100, coolDownOffset: 1500),
                    new Shoot(5, projectileIndex: 0, count: 1, shootAngle: 0, coolDown: 900, coolDownOffset: 1500),
                    new Shoot(5, projectileIndex: 0, count: 1, shootAngle: 0, coolDown: 700, coolDownOffset: 1500),
                    new TimedTransition(20000, "death")
                        ),
                    new State("death",
                        new Decay(0)
                        )
                ))
                .Init("lod Mirror Wyvern3",
                new State(
                    new State("attack",
                    new Shoot(5, projectileIndex: 0, count: 1, shootAngle: 0, coolDown: 1500, coolDownOffset: 1500),
                    new Shoot(5, projectileIndex: 0, count: 1, shootAngle: 0, coolDown: 1300, coolDownOffset: 1500),
                    new Shoot(5, projectileIndex: 0, count: 1, shootAngle: 0, coolDown: 1100, coolDownOffset: 1500),
                    new Shoot(5, projectileIndex: 0, count: 1, shootAngle: 0, coolDown: 900, coolDownOffset: 1500),
                    new Shoot(5, projectileIndex: 0, count: 1, shootAngle: 0, coolDown: 700, coolDownOffset: 1500),
                    new TimedTransition(20000, "death")
                        ),
                    new State("death",
                        new Decay(0)
                ))
            )
                .Init("lod Mirror Wyvern4",
                new State(
                    new State("attack",
                    new Shoot(5, projectileIndex: 0, count: 1, shootAngle: 0, coolDown: 1500, coolDownOffset: 1500),
                    new Shoot(5, projectileIndex: 0, count: 1, shootAngle: 0, coolDown: 1300, coolDownOffset: 1500),
                    new Shoot(5, projectileIndex: 0, count: 1, shootAngle: 0, coolDown: 1100, coolDownOffset: 1500),
                    new Shoot(5, projectileIndex: 0, count: 1, shootAngle: 0, coolDown: 900, coolDownOffset: 1500),
                    new Shoot(5, projectileIndex: 0, count: 1, shootAngle: 0, coolDown: 700, coolDownOffset: 1500),
                    new TimedTransition(20000, "death")
                        ),
                    new State("death",
                        new Decay(0)
                ))
            );

    }
}
