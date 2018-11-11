using Payment.Business.Entities;
using Payment.Business.Interfaces;
using Payment.DataAccess.Dtos.Dtos;
using Payment.DataAccess.Interfaces.IRepositories;
using System;

namespace Payment.Business
{
    public class PaymentBusiness : IPaymentBusiness
    {
        private readonly ICardRepository cardRepository;
        private readonly ICardTypeRepository cardTypeRepository;
        private readonly IBalanceRepository balanceRepository;
        private readonly ITransactionRepository transactionRepository;

        public PaymentBusiness(ICardRepository cardRepository,
            ICardTypeRepository cardTypeRepository,
            IBalanceRepository balanceRepository,
            ITransactionRepository transactionRepository)
        {
            this.cardRepository = cardRepository;
            this.balanceRepository = balanceRepository;
            this.transactionRepository = transactionRepository;
        }

        public TransactionEntity Pay(PurchaseEntity purchase)
        {
            var card = cardRepository.GetByCardNumber(purchase.CardNumber);
            if (!IsValidCreditCard(purchase, card)) throw new Exception();
            var balance = balanceRepository.GetByCreditCardId(card.CardId);
            if (!HasBalance(balance, card.CardId, purchase.Cost)) throw new Exception();
            var transactionId = SaveTransaction(purchase, card, balance);
            SaveBalance(balance.Balance, purchase.Cost, card.CardId);

            return new TransactionEntity() {TransactionId = transactionId, TransactionDate = DateTime.Now };
        }

        private bool IsValidCreditCard(PurchaseEntity entity, CardDto card)
        {
            if (card == null) return false;
            var cardType = cardTypeRepository.GetById(card.CardTypeId);
            if (cardType == null) return false;

            return  entity.CardType == cardType.Code &&
                    entity.CardExpireDate.ToString("MM") == card.ExpireDate.ToString("MM") &&
                    entity.CardExpireDate.ToString("yyyy") == card.ExpireDate.ToString("yyyy") &&
                    entity.CardExpireDate <= DateTime.Today &&
                    entity.CardCvv == card.Cvv;
        }

        private bool HasBalance(BalanceDto balance, int cardId, decimal cost)
        {
            if (balance == null) return false;
            return balance.Balance >= cost;
        }

        private string SaveTransaction(PurchaseEntity purchase, CardDto card, BalanceDto balance)
        {
            var today = DateTime.Today;
            var transactionId = card.Number + today.ToString("dd-MM-yyyy-HH-mm-ss");
            var transaction = new TransactionDto()
            {
                Description = purchase.Description,
                Cost = purchase.Cost,
                Date = today,
                CardId = card.CardId,
                InitialBalance = balance.Balance,
                FinalBalance = balance.Balance - purchase.Cost,
                TransactionId = transactionId
            };

            transactionRepository.Insert(transaction);

            return transactionId;
        }

        private void SaveBalance(decimal balance, decimal cost, int cardId)
        {
            var finalBalance = balance - cost;
            var balanceDto = balanceRepository.GetByCreditCardId(cardId);
            balanceDto.Balance = finalBalance;
            balanceRepository.Update(balanceDto);
        }
    }
}