using System;

namespace _Chainblock.Models
{
    using Contracts;

    public class Transaction : ITransaction
    {
        private int _id;
        private string _from;
        private string _to;
        private double _amount;

        public Transaction(int id, TransactionStatus status, string from, string to, double amount)
        {
            this.Id = id;
            this.Status = status;
            this.From = from;
            this.To = to;
            this.Amount = amount;
        }

        public int Id
        {
            get
            {
                return this._id;
            }
            set
            {
                if (value <= 0)
                {
                    throw new InvalidOperationException("Id cannot be zero or negative!");
                }

                this._id = value;
            }
        }

        public TransactionStatus Status { get; set; }

        public string From
        {
            get
            {
                return this._from;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new InvalidOperationException("Sender cannot be null or empty!");
                }

                this._from = value;
            }
        }

        public string To
        {
            get
            {
                return this._to;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new InvalidOperationException("Receiver cannot be null or empty!");
                }

                this._to = value;
            }
        }

        public double Amount
        {
            get
            {
                return this._amount;
            }
            set
            {
                if (value <= 0)
                {
                    throw new InvalidOperationException("Amount cannot be zero or negative!");
                }

                this._amount = value;
            }
        }

        /// <summary>
        /// If you want to keep unique transaction ids in HashSet use this below...
        /// </summary>

        public override bool Equals(object? obj)
        {
            if (obj is Transaction)
            {
                return ((Transaction)obj).Id.Equals(this.Id);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
