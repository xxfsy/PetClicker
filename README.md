# PetClicker
My project with a focus on architecture and coding parts. This is a clicker on MVP-Supervising controller architecture

Used design patterns: MVP, Pure Dependency Injection, Entrypoint, EventBus, Observer

---

Status: in development

Try Game: https://xxfsy.itch.io/petclicker

---

Drawbacks and Areas for Improvement:

1) Excessive abstraction in some parts
Some parts of the project contain abstractions added “for growth.” This simplifies scaling and maintenance but raises the entry barrier and is somewhat redundant for the current scope of functionality. In the future, I plan to refactor and simplify the architecture, keeping only the truly necessary levels of abstraction.

2) Some redundancy in component relationships
There is some redundancy in the relationships between components due to the effort to strictly follow SOLID and DIP principles. As a result, the architecture is flexible and extensible, but in some places it is excessively layered for the scale of the current project.
