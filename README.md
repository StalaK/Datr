# Datr
Create object instances with pre-populated properties to speed up test writing

## Creating Object Instances
Initialise a new Datr class and call the Create function, passing in the Type of object to be created
```
var datr = new Datr();
var myClass = datr.Create<MyClass>();
```

## Excluding Properties
There are two ways to exclude properties from being populated when an object is created.
The first is by property name. To do this, add the property name to the ExcludedPropertyNames list in the Datr instance. This will stop all properties with the entered name from being populated across all classes.
```
var datr = new Datr();
datr.IgnoredPropertyNames.Add("MyExcludedProperty");
var myClass = datr.Create<MyClass>();
```

The second way to exclude a property is by type and property name. This allows you to exclude properties on specified classes whilst allowing properties with the same name to be populated in other classes. To exclude a property in the manner, add a new TypeProperty object to the ExcludedTypeProperties list in the Datr instance
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
