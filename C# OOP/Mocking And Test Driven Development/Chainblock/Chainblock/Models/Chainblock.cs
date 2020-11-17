using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using _Chainblock.Models.Contracts;

namespace _Chainblock.Models
{
    public class Chainblock : IChainblock
    {
        private readonly ICollection<ITransaction> transactions;

        public Chainblock()
        {
            this.transactions = new List<ITransaction>();
        }

        public int Count => this.transactions.Count;

        public void Add(ITransaction tx)
        {
            if (!this.Contains(tx))
            {
                this.transactions.Add(tx);
            }
        }

        public bool Contains(ITransaction tx)
            => this.transactions.Any(x => x.Equals(tx));

        public bool Contains(int id)
            => this.transactions.Any(x => x.Id == id);

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            if (!this.Contains(id))
            {
                throw new ArgumentException("Transaction with given Id is not exist!");
            }

            var tr = this.GetById(id);

            tr.Status = newStatus;
        }

        public void RemoveTransactionById(int id)
        {
            var tr = this.GetById(id);

            this.transactions.Remove(tr);
        }

        public ITransaction GetById(int id)
        {
            if (!this.Contains(id))
            {
                throw new InvalidOperationException("Transaction with given Id is not exist!");
            }

            return this.transactions.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            if (!(this.transactions.Any(x => x.Status == status)))
            {
                throw new InvalidOperationException("Not exist Transaction with given status!");
            }

            return this.transactions.Where(x => x.Status == status).OrderByDescending(x => x.Amount);
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
            => this.GetByTransactionStatus(status).Select(x => x.From);

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
            => this.GetByTransactionStatus(status).Select(x => x.To);

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
            => this.transactions.OrderByDescending(x => x.Amount).ThenByDescending(x => x.Id);

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            if (!(this.transactions.Any(x => x.From == sender)))
            {
                throw new InvalidOperationException("Not contains transaction with given sender!");
            }

            return this.transactions.Where(x => x.From == sender)
                .OrderByDescending(x => x.Amount);
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            if (!(this.transactions.Any(x => x.To == receiver)))
            {
                throw new InvalidOperationException("Not contains transaction with given sender!");
            }

            return this.transactions.Where(x => x.To == receiver)
                .OrderByDescending(x => x.Amount)
                .ThenBy(x => x.Id);
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
            => this.transactions.Where(x => x.Status == status && x.Amount <= amount)
                .OrderByDescending(x => x.Amount);

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            var result = this.transactions.Where(x => x.From == sender && x.Amount > amount);

            if (!result.Any())
            {
                throw new InvalidOperationException("Transactions not exist!");
            }

            return result.OrderByDescending(x => x.Amount);
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            var result = this.transactions.Where(x => x.To == receiver && x.Amount >= lo && x.Amount < hi);

            if (!result.Any())
            {
                throw new InvalidOperationException("Transactions not exist!");
            }

            return result.OrderByDescending(x => x.Amount).ThenByDescending(x => x.Id);
        }

        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
            => this.transactions.Where(x => x.Amount >= lo && x.Amount <= hi);

        public IEnumerator<ITransaction> GetEnumerator()
            => this.transactions.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}
