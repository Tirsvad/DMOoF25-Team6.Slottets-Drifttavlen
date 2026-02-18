// Copyright (c) 2026 Team6. All rights reserved. 
//  No warranty, explicit or implicit, provided.

namespace Domain.Tests;

[Collection("Basic collection")]
public sealed class Test1 : IDisposable
{
    [Fact(DisplayName = "Simple Addition Test")]
    public void SimpleAdditionTest()
    {
        // Assert that basic arithmetic works as expected.
        int testvar = 2 + 2;

        // Test that 2 + 2 equals 4
        Assert.Equal(4, testvar);
    }

    public void Dispose()
    {
    }
}
