namespace ENB.ApartmentRentals.Entities
{
    /// <summary>
    /// Determines the type of a contact person.
    /// </summary>
    public enum Ref_Booking_status
    {
        /// <summary>
        /// Indicates an unidentified value.
        /// </summary>
        None = 0,

        /// <summary>
        /// Indicates a provisional Booking_status.
        /// </summary>
        Provisional = 1,

        /// <summary>
        /// Indicates a confirmed Booking_status.
        /// </summary>
        Confirmed = 2,

        /// <summary>
        /// Indicates a cancelled Booking_status.
        /// </summary>
        Cancelled = 3
        
       
    }
}
