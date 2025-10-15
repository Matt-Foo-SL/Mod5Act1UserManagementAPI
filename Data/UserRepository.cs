using Mod5Act1UserManagementAPI.Models;

namespace Mod5Act1UserManagementAPI.Data
{
    public static class UserRepository
    {
        private static List<User> _users = new List<User>();
        private static int _nextId = 0;

        public static List<User> GetAll() => _users;

        public static User? GetById(int id) => _users.FirstOrDefault(u => u.Id == id);

        public static User Add(User user)
        {
            user.Id = _nextId++;
            _users.Add(user);
            return user;
        }

        public static bool Update(int id, User updatedUser)
        {
            var existing = GetById(id);
            if (existing == null) return false;

            existing.FirstName = updatedUser.FirstName;
            existing.LastName = updatedUser.LastName;
            existing.Email = updatedUser.Email;
            existing.Department = updatedUser.Department;
            return true;
        }

        public static bool Delete(int id)
        {
            var user = GetById(id);
            if (user == null) return false;
            _users.Remove(user);
            return true;
        }
    }
}
