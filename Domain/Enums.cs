﻿namespace Domain
{
    public class Enums
    {
        public enum RequestType
        {
            GET,
            POST,
            DELETE,
            PUT
        }
        public enum Action
        {
            Create,
            Update,
            Delete,
            None
        }
        public enum OrganizationType
        {
            Department,
            Organization
        }
        public enum NotificationType
        {
            PageRequest,
            Comment,
            Post
        }
        public enum PageRequestStatus
        {
            Pending,
            Approved,
            Rejected
        }
    }
}
