# Domain Models

## Menu Behaviors

```csharp
class Menu
{
  Menu Create();
  void AddDinner(Dinner dinner);
  void RemoveDinner(Dinner dinner);
  void UpdateSection(MenuSection section);
}
```

## Menu aggregate preview

```json
{
  "id": "1",
  "name": "Yummy menu",
  "description": "A menu with yummy foods",
  "AverageRating": 4.5,
  "sections": [
    {
      "id": "22",
      "name": "Appetizers",
      "description": "Starters",
      "items": [
        {
          "id": "882",
          "name": "Fried Pickles",
          "description": "Deep fried pickles",
          "price": 5.99
        }
      ]
    }
  ],
  "createdDateTime": "2023-07-01T09:17:30.883Z",
  "updatedDateTime": "2023-07-01T09:17:30.883Z",
  "hostId": "23",
  "dinnerIds": ["21", "78", "65"],
  "reviewMenuIds": ["11", "54", "22"]
}
```
