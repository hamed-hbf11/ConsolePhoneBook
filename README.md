# 📞 Console Phone Book App

A clean, object-oriented C# console application designed for managing contacts with JSON file persistence, Iranian phone number validation, and Git version control.

---

## ✨ Features

- **Contact Management:** Add, display, search, edit, and delete contacts.
- **Data Persistence:** Automatically saves and loads contacts to/from a local `contacts.json` file.
- **Validation:**
  - Prevents duplicate phone numbers.
  - Validates Iranian phone number formats (Must be 11 digits, numeric-only, starting with `09`).
- **Clean Architecture & OOP:**
  - Strict separation of concerns (UI/Program, Business Logic/PhoneBook, Data Model/Contact, Utility/PhoneValidator).
  - Encapsulated collection management using `IReadOnlyList<Contact>`.

---

## 🛠️ Tech Stack & Concepts

- **Language:** C# (.NET)
- **Data Serialization:** `System.Text.Json`
- **Queries:** LINQ
- **Version Control:** Git & GitHub (Structured Git Commits)

---

## 📁 Project Structure

```text
PhoneBookApp/
│
├── Contact/
│   └── Contact.cs          # Data Model for a single contact
│
├── PhoneBook/
│   └── PhoneBook.cs        # Core business logic & JSON file persistence
│
├── Utility/
│   └── PhoneValidator.cs   # Helper for validating Iranian phone number formats
│
├── .gitignore              # Git ignore rules
├── contacts.json           # Local JSON database file
├── PhoneBookApp.csproj     # C# Project File
├── Program.cs              # Console UI & menu handling
└── README.md               # Project documentation
