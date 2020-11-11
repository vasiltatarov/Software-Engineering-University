using System;

namespace ValidationAttributes.Attributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private readonly int _minValue;
        private readonly int _maxValue;

        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.ValidateRange(minValue, maxValue);
            this._minValue = minValue;
            this._maxValue = maxValue;
        }

        public override bool IsValid(object obj)
        {
            var isAge = obj is Int32;

            if (isAge)
            {
                var age = (int) obj;

                return age >= this._minValue && age <= this._maxValue;
            }
            else
            {
                throw new InvalidOperationException("Invalid object type!");
            }
        }

        private void ValidateRange(int minValue, int maxValue)
        {
            if (minValue > maxValue)
            {
                throw new ArgumentException("Invalid range!");
            }
        }
    }
}
