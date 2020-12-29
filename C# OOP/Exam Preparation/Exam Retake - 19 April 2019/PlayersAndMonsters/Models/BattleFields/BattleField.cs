using System;
using System.Linq;
using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Models.Players.Contracts;

namespace PlayersAndMonsters.Models.BattleFields
{
    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            CheckIfNotDead(attackPlayer, enemyPlayer);

            IncreaseStatsIfNeeded(attackPlayer);
            IncreaseStatsIfNeeded(enemyPlayer);

            GetBonusHealth(attackPlayer);
            GetBonusHealth(enemyPlayer);

            var attackPlayerDamage = attackPlayer.CardRepository
                .Cards
                .Sum(x => x.DamagePoints);

            var enemyPlayerDamage = enemyPlayer.CardRepository
                .Cards
                .Sum(x => x.DamagePoints);

            while (true)
            {
                enemyPlayer.TakeDamage(attackPlayerDamage);

                if (enemyPlayer.IsDead)
                {
                    break;
                }

                attackPlayer.TakeDamage(enemyPlayerDamage);

                if (attackPlayer.IsDead)
                {
                    break;
                }
            }
        }

        private void Attack(IPlayer attacker, IPlayer defender)
        {
            foreach (var card in attacker.CardRepository.Cards)
            {
                if (defender.IsDead)
                {
                    return;
                }

                defender.Health -= card.DamagePoints;
            }
        }

        private void GetBonusHealth(IPlayer player)
        {
            foreach (var card in player.CardRepository.Cards)
            {
                player.Health += card.HealthPoints;
            }
        }

        private void IncreaseStatsIfNeeded(IPlayer player)
        {
            if (player is Beginner)
            {
                player.Health += 40;

                foreach (var card in player.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            }
        }

        private void CheckIfNotDead(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead || enemyPlayer.IsDead)
            {
                throw new ArgumentException("Player is dead!");
            }
        }
    }
}