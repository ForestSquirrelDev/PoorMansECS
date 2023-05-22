# PoorMansECS

As the name suggests, it's an ECS library. But of a poor man.

Library is implemented using built-in C# types. It provides a very simplistic ECS-like implementation without advanced features like Archetypes, expecting you to create an instance of World manually, as well as systems.

Library offers an Entity-Component models that rely heavily on type introspection, making it suitable for small projects where performance isn't critical and you want to keep things simple yet not too much spaghettified.
