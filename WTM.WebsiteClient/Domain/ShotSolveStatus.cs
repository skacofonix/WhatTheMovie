﻿namespace WTM.WebsiteClient.Domain
{
    public enum ShotSolveStatus
    {
        /// <summary>
        /// Never solved by anyone
        /// </summary>
        Unsolved,

        /// <summary>
        /// Never solved by the player
        /// </summary>
        PlayerUnsolved,

        /// <summary>
        /// Solved by the player
        /// </summary>
        Solved
    }
}