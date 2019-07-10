﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.DomainModel
{
    public abstract class AggregateRoot : Entity
    {
        public Guid Id { get; private set; }

        public string UserId { get; private set; }

        public AggregateRoot(Guid id, string userId)
        {
            Id = id;

            UserId = userId;
        }

        protected AggregateRoot()
        {

        }

        /// <summary>
        /// Id for item
        /// </summary>
        //public string Id { get; set; }

        /// <summary>
        /// Azure created at time stamp
        /// </summary>
        public DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// Azure UpdateAt timestamp for online/offline sync
        /// </summary>
        public DateTimeOffset UpdatedAt { get; set; }

        /// <summary>
        /// Azure version for online/offline sync
        /// </summary>
        public string AzureVersion { get; set; }
    }
}
