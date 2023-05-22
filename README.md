# PoorMansECS

As the name suggests, it's an ECS library. But of a poor man.

Library is implemented using built-in C# types. It provides a very simplistic ECS-like implementation without advanced features like Archetypes, expecting you to:
1. Create an instance of World manually.
2. Create the systems manually, calling the CreateSystem<T>() method of World.
3. Start and update the World manually, using whatever kind of game loop.

For communication between systems there's a [SystemsEventBus](https://github.com/ForestSquirrelDev/PoorMansECS/blob/master/SystemsEventBus.cs). It expects you to derive your system from [ISystemEventListener](https://github.com/ForestSquirrelDev/PoorMansECS/blob/master/ISystemEventListener.cs) and subscribe for an event of certain type.

Entity-Component models rely heavily on type introspection.

This library might be suitable for small projects where performance isn't critical and you want to keep things simple yet not too much spaghettified.
