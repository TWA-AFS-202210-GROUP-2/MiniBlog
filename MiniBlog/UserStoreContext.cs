﻿using MiniBlog;
using MiniBlog.Model;

public class UserStoreContext : IUserStore
{
    private List<User> users = new List<User>();

    public List<User> GetAll()
    {
        return this.users;
    }

    public User Save(User user)
    {
        this.users.Add(user);
        return user;
    }

    public bool Delete(User user)
    {
        return this.users.Remove(user);
    }

    public void Init()
    {
        users = new List<User>();
    }

}