# RoleBasedLoginSystem

A simple role-based login system implemented in C# using in-memory data (Lists) for testing purposes.  
Designed to demonstrate how to structure a system for multiple user roles (Student, Teacher, Admin) while keeping the code clean, scalable, and OCP-compliant.

---

## Scenario

Imagine a school management system where different users log in:

- **Student**: Person + User + Student-specific data  
- **Teacher**: Person + User + Teacher-specific data  
- **Admin / Manager**: Person + User only (no extra role-specific data)  

We want a system where:

1. Login logic is shared between roles.
2. Adding a new role (like Accountant) should be fast and require minimal code change.
3. Registration is role-specific but shares a common User creation logic.
4. All data is kept in memory (no database) for testing and fast iteration.

---

## Problem

Traditional approaches often duplicate code for each role:

- Login logic repeated for every role.
- RoleID hard-coded multiple times.
- Adding a new role requires editing multiple parts of the code.
- Registration logic is scattered, making it hard to manage and extend.

---

## Solution

1. **Abstract Class `clsRoleUser`**:  
   - Contains shared login logic (`LoginAs<T>`).  
   - Child roles (Student, Teacher) only provide RoleID and role-specific data.

2. **Generic Method + Func Delegate**:  
   - `LoginAs<T>` uses a method pointer (`Func<int, T>`) to fetch the full object.  
   - Works for any role (Student, Teacher, future roles).

3. **Separate Registration for Roles**:  
   - `clsUser.CreateUser()` creates the basic user.  
   - Each role (`clsStudent`, `clsTeacher`) adds role-specific data.  

4. **Admin / Manager**:  
   - If a role has no additional data, it can login directly from `clsUser` without creating a separate class.

5. **Scalable**:  
   - Adding a new role like Accountant is easy:  
     - Create RoleID  
     - Add Registration method (if needed)  
     - Add optional class if role has extra data  
   - No need to change existing login logic.

---

## How It Works (Workflow)

1. Registration:
   - `clsUser.CreateUser()` → creates basic user.
   - Role class adds role-specific data (e.g., Student info).

2. Login:
   - Call `Login()` method of role class.
   - `LoginAs<T>` searches in `clsUser.Users` by RoleID and credentials.
   - If found, fetch full role-specific object using the passed delegate.

3. Adding a New Role:
   - Add new RoleID in `clsUser`.
   - Create a new role class if it has extra data, or use `clsUser` for login if no extra data.
   - Add registration logic if needed.

---

## Steps to Push to GitHub

1. Create a new repository on GitHub named `RoleBasedLoginSystem`.
2. Initialize git in your project folder:

```bash
cd path_to_project
git init
