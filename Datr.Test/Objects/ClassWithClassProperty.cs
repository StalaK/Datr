using System.Collections.Generic;

namespace Datr.Test.Objects;

public class ClassWithClassProperty
{
    public ValuesClass ValuesClass { get; set; }
    public string MainClassString { get; set; }
    public int MainClassInt { get; set; }
    public ValuesClass[] ValuesClassArray { get; set; }
    public List<ValuesClass> ValuesClassList { get; set; }
}
