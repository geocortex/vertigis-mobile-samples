using System;
using System.Collections.Generic;
using System.Text;

namespace VertiGIS.Mobile.Samples.SampleSelector
{
    public class SampleGroup : List<Sample>
    {
        public string Name { get; private set; }

        public SampleGroup (string name, List<Sample> samples) : base(samples)
        {
            Name = name;
        }
    }
}
