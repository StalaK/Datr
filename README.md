# Datr
Create object instances with pre-populated properties to speed up test writing

## Installation
Package Manager:
`Install-Package Datr -Version 1.0.0`

.NET CLI:
`dotnet add package Datr --version 1.0.0`

## Creating Object Instances
Initialise a new Datr class and call the Create function, passing in the Type of object to be created

### Example
```
var datr = new Datr();
var myClass = datr.Create<MyClass>();
```

## Excluding Properties
There are two ways to exclude properties from being populated when an object is created.
The first is by property name. To do this, add the property name to the ExcludedPropertyNames list in the Datr instance. This will stop all properties with the entered name from being populated across all classes.

### Example
```
var datr = new Datr();
datr.IgnoredPropertyNames.Add("MyExcludedProperty");
var myClass = datr.Create<MyClass>();
```

The second way to exclude a property is by type and property name. This allows you to exclude properties on specified classes whilst allowing properties with the same name to be populated in other classes. To exclude a property in the manner, add a new TypeProperty object to the ExcludedTypeProperties list in the Datr instance.
```
var datr = new Datr()
{
    ExcludedTypeProperties = new List<TypeProperty>
    {
        new TypeProperty(typeof(MyClass), "MyExcludedProperty")
    }
};
```
All excluded properties are case insensitive

## Fixing Property Values
It's possible to set a property's value to a specific value of your choosing by adding a new FixedValue object to the FixedValues list of the Datr instance or replacing it with a new `List<FixedValue>`.

### Example
```
var propertyValue = "Hello World!"
var datr = new Datr();
datr.FixedValues.Add(new FixedValue(typeof(MyClass), "MyProperty", propertyValue)

var classInstance = datr.Create<MyClass>();
```
The above example ensures that `classInstance.MyProperty == "Hello World!"`.

## Generating Random Data Within a Range
If the data is required to be within a specific boundary, this can be configured using the set range functions. The following data types are supported:
* Int
* UInt
* Decimal
* Byte
* SByte
* Short
* UShort
* Float
* Double
* Long
* ULong
* String (length)
* DateTime

There are four possible ranges which can be selected by the `Range` enum.

#### GreaterThan
Ensures the entered property's value is greater than the `minValue` parameter value.

#### LessThan
Ensures the entered property's value is less than the `maxValue` parameter value.

#### Between
Ensures the entered property's value is greater than the `minValue` parameter value and less than the `maxValue` parameter value.

#### Outside
Ensures the entered property's value is less than the `minValue` parameter value or greater than the `maxValue` parameter value.

### Example
```
var datr = new Datr();
datr.SetIntRange<MyClass>("MyIntProperty", Range.GreaterThan, 1000);

var classInstance = datr.Create<MyClass>();
```

In the above example `classInstance.MyIntProperty` will always be a value greater than 1000.
