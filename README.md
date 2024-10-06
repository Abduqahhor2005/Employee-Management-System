# Employee Management System

## Описание
Employee Management System — это веб-приложение, предназначенное для управления сотрудниками. Приложение позволяет:
- Добавлять новых сотрудников.
- Обновлять информацию о сотрудниках.
- Удалять сотрудников.
- Просматривать список сотрудников.

Приложение построено на базе ASP.NET Core с использованием Entity Framework Core и PostgreSQL для работы с базой данных.

## Требования
Перед установкой убедитесь, что у вас установлены следующие компоненты:
- .NET 6.0 SDK или новее
- PostgreSQL
- Git

## Получить всех сотрудников:
GET /api/employees

## Добавить нового сотрудника:
POST /api/employees
Content-Type: application/json

{
"firstName": "John",
"lastName": "Doe",
"dateOfBirth": "1990-01-01",
"position": "Developer",
"salary": 60000
}

## Обновить информацию о сотруднике:
PUT /api/employees/{id}
Content-Type: application/json

{
"firstName": "Jane",
"lastName": "Doe",
"dateOfBirth": "1991-02-02",
"position": "Manager",
"salary": 70000
}

## Удалить сотрудника:
DELETE /api/employees/{id}