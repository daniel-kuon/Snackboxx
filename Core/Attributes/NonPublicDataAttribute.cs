using System;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Core.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class NonPublicDataAttribute: Attribute
    {
        
    }
}