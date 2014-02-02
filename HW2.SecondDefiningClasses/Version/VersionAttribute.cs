//// Create a [Version] attribute that can be applied to structures, classes, interfaces, enumerations and methods and holds a 
//// version in the format major.minor (e.g. 2.11). Apply the version attribute to a sample class and display its version at runtime.

namespace Version
{
    using System;
    using System.Runtime.InteropServices;

    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Enum | AttributeTargets.Method, AllowMultiple = true)]

    public class VersionAttribute : Attribute
    {        
        public VersionAttribute(int major, int minor)
        {
            this.Major = major;
            this.Minor = minor;
        }

        public int Major { get; set; }

        public int Minor { get; set; }

        public string Version
        {
            get
            {
                return string.Format("{0}.{1}", this.Major, this.Minor);
            }
            
            set 
            { 
            }
        }
    }
}
