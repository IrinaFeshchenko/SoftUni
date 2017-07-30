using System;
[AttributeUsage(AttributeTargets.Class|AttributeTargets.Enum)]
public class TypeAttribute : Attribute
{
    public TypeAttribute(string category, string description)
    {
        Category = category;
        Description = description;
        this.Type = "Enumeration";
    }
    
    public string Type { get; }

    public string Category { get; set; }

    public string Description { get; set; }

    public override string ToString()
    {
        return $"Type = {this.Type}, Description = {this.Description}";
    }
}
