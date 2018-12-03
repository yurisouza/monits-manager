using System;

namespace MonitsManager.Domain
{
    public class User
    {
        public Guid UserKey { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string DocumentNumber { get; set; }
        public string DocumentType { get; set; }
        public string Password { get; set; }
    }
}
