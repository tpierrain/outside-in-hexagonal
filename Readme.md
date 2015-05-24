Outside-in hexagonal this!
============================

__A code kata by [@tpierrain](https://twitter.com/tpierrain)__

## Objective
Implement a *"service"* that is able to provide *Pasta Recipes* following the __outside-in TDD approach__ and the __hexagonal architecture__ to prevent domain code from being impacted by infrastructure code.

## Details

 1. The *"service"* should allow its consumers:
  - to get the *Recipe* (i.e. the list of the ingredients) of a *Pasta* given its name
  - to get the list of all the *Pastas* that have a given *Ingredient*
  - to add the *Recipe* of a new *Pasta* and to persist it

 2. A *Pasta Recipe* is a list of ingredient associated with the name of a *Pasta*. E.g.:
  - gnocchi(eggs-potatoes-flour)
  - spaghetti(eggs-flour)
  - organic spaghetti(organic eggs-flour)
  - spinach farfalle(eggs-flour-spinach)
  - tagliatelle(eggs-flour)

 3. __The domain model should not be the same as the one for the communication__ with the service consumers (i.e. the DTOs).
