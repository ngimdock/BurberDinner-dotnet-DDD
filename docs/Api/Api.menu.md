# Buber dinner API

- Menu
  - Create menu
    - Create menu request
    - Create menu response

# Menu

## Create menu request

```http
POST /hosts/{hostId}/menus
```

```json
{
  "name": "Yummy Menu",
  "description": "A menu with yummy food",
  "sections": [
    {
      "name": "Appetizers",
      "description": "Starters",
      "items": [
        {
          "name": "Fried Pickles",
          "description": "Deep fried pickles"
        }
      ]
    }
  ]
}
```

## Create menu response

```http
Status 200 ok
```

```json
{
  "id": "00000000-0000",
  "name": "Yummy Menu",
  "description": "A menu with yummy food",
  "averageRating": null,
  "sections": [
    {
      "id": "00000000-0000",
      "name": "Appetizers",
      "description": "Starters",
      "items": [
        {
          "id": "00000000-0000",
          "name": "Fried Pickles",
          "description": "Deep fried pickles"
        }
      ]
    }
  ],
  "hostId": "00000000-0000",
  "dinnerIds": [],
  "menuReviewIds": [],
  "createdDateTime": "2020-01-01T00:00:00.0000000Z",
  "updatedDateTime": "2020-01-01T00:00:00.0000000Z"
}
```
