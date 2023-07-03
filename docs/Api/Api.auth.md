# Buber dinner API

- Auth

  - Register

    - Register Request
    - Register Response

  - Login
    - Login Request
    - Login Response

# Auth

## Register

## Register request

```http
POST /auth/register
```

```json
{
  "firstname": "Ngimdock",
  "lastname": "Zemfack",
  "email": "ngimdock@gmail.com",
  "password": "000000"
}
```

# Register response

```http
Status 200 ok
```

```json
{
  "id": "00000000-0000",
  "firstname": "Ngimdock",
  "lastname": "Zemfack",
  "email": "ngimdock@gmail.com",
  "token": "token"
}
```

# Login

## Login Request

```http
POST /auth/login
```

```json
{
  "email": "ngimdock@gmail.com",
  "password": "000000"
}
```

## Login response

```http
Status 200 ok
```

```json
{
  "id": "00000000-0000",
  "firstname": "Ngimdock",
  "lastname": "Zemfack",
  "email": "ngimdock@gmail.com",
  "token": "token"
}
```
