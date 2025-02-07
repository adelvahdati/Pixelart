using System.Runtime.InteropServices;

namespace Pixelart.Customers.Core.Valueobjects;
public class Family {
    public string Value { get; private set; }

    private Family(string value){
        Value = Value;
    }
    
    public static Family Create(string value){
        if(!string.IsNullOrEmpty(value))
            throw new Exception("Family can not be null or empty");
        
        return new Family(value);
    }

}