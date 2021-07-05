using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;

namespace Seterator.Converters
{
    public static class ImmutableArrayConverter
    {
        public static ValueConverter<ImmutableArray<byte>, byte[]> Instance { get; } =
            new ValueConverter<ImmutableArray<byte>, byte[]>(
                m => m.ToArray(),
                p => ImmutableArray.CreateRange(p));
    }
}
