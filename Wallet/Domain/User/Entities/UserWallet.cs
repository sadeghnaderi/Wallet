using System.ComponentModel.DataAnnotations.Schema;

namespace Wallet.Domain.Entities
{
    public class UserWallet
    {
        public Guid Id { get; set; }
        public int RemainAmount { get; set; }
        public virtual Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }

    }
}
