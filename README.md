# RoleBasedLoginSystem

A simple role-based login system implemented in C# using in-memory Lists for testing purposes.  
The goal: demonstrate how to structure a system for multiple user roles (Student, Teacher, Admin) in a clean, scalable, and maintainable way.

---

## Scenario

Imagine a school management system with multiple types of users:

- **Student**: Person data + User data + Student-specific information  
- **Teacher**: Person data + User data + Teacher-specific information  
- **Admin / Manager**: Person data + User data only (no extra role-specific information)  

We want a system where:

1. Login logic is shared between roles.  
2. Adding a new role (like Accountant) is fast and requires minimal code changes.  
3. Registration is role-specific but shares common User creation logic.  
4. All data is stored in memory (Lists) for testing and quick iteration.  

---

## Problem

Traditional approaches often duplicate code for each role:

- Login logic repeated for every role  
- RoleID hard-coded in multiple places  
- Adding a new role requires editing multiple files  
- Registration logic is scattered, making it hard to maintain  

---

## Solution

1. **Abstract Class `clsRoleUser`**:  
   - Contains shared login logic (`LoginAs<T>`)  
   - Child roles (Student, Teacher) provide only RoleID and role-specific data  

2. **Generic Method + Func Delegate**:  
   - `LoginAs<T>` uses a method pointer (`Func<int, T>`) to fetch the full object  
   - Works for any role (Student, Teacher, future roles)  

3. **Separate Registration for Roles**:  
   - `clsUser.CreateUser()` creates the basic user  
   - Each role (`clsStudent`, `clsTeacher`) adds role-specific data  

4. **Admin / Manager**:  
   - If a role has no additional data, it can login directly from `clsUser` without creating a separate class  

5. **Scalable Design**:  
   - Adding a new role like Accountant is easy:  
     - Add a RoleID  
     - Add a registration method (if needed)  
     - Create a role class only if additional data is required  
   - No need to modify existing login logic  

---

## How It Works (Workflow)

1. **Registration**:
   - `clsUser.CreateUser()` → creates basic user  
   - Role class adds role-specific data (e.g., Student info)  

2. **Login**:
   - Call `Login()` method of role class  
   - `LoginAs<T>` searches in `clsUser.Users` by RoleID and credentials  
   - If found, fetch full role-specific object using the passed delegate  

3. **Adding a New Role**:
   - Add new RoleID in `clsUser`  
   - Create a new role class only if it has extra data  
   - Add registration logic if needed  

---

## Example Usage

```csharp
// Register a Student
clsStudent.RegisterStudent(
    "student1",
    "123",
    "Ali",
    "Hassan",
    20,
    "Male");

// Login as Student
clsStudent student = (clsStudent)new clsStudent().Login("student1", "123");

// Register a Teacher
clsTeacher.RegisterTeacher(
    "teacher1",
    "abc",
    "Sara",
    "Mohamed",
    30,
    "Female");

// Login as Teacher
clsTeacher teacher = (clsTeacher)new clsTeacher().Login("teacher1", "abc");

// Login as Admin
clsUser admin = clsUser.LoginAsAdmin("admin1", "adminpass");
