using System;
using XCalculateLib;

namespace DateTimeCalculators
{
    [Function]
    public class AddDaysFunction : BaseFunction
    {
        public AddDaysFunction()
            : base(new FunctionInfo(new Version("1.0.0"), "Add Days", new ValueInfo("Date", "Offset date."), "Calculates the date that is a number of days from a certain date.", "date", "add", "day"),
                  new DateTimeValue(DateTime.Now, new ValueInfo("Date from which to calculate.")),
                  new Int32Value(0, new ValueInfo("Days", "The number of days to add.  Can be negative.", new DayUnit())))
        {
        }

        public override IValue[] Calculate(IValue[] inputs)
        {
            this.CheckInputs(inputs);

            var date = (DateTime)inputs[0].Value;
            var days = (int)inputs[1].Value;

            var newDate = date + new TimeSpan(days, 0, 0, 0);

            return this.CreateResults(new DateTimeValue(newDate));
        }
    }
}
