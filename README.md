# PoorMansECS

As the name suggests, it's an ECS library. But of a poor man.

Library is implemented using built-in C# types. It provides a very simplistic ECS-like implementation without advanced features like Archetypes or World.

It offers an Entity-Component models with O(n) 💩 complexity for entity traversal, making it suitable for small projects where performance isn't critical and you want to keep things simple yet not too much spaghettified.