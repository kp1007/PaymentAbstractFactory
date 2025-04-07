# 📘 Payment Processing System (Learning Project)

A C# console application demonstrating the **Abstract Factory Design Pattern** applied to a real-world scenario — a payment processing system supporting multiple gateways (Stripe, PayPal, Square).

This project is designed with **best practices in mind** and can be **easily extended into a web-based API** using ASP.NET Core.

## 🚀 Features

- Demonstrates the **Abstract Factory Pattern** to handle:
  - Payment processing
  - Refunds
  - Transaction status checks
- Supports **multiple gateways**: Stripe, PayPal, Square
- Console interface simulates real-world interactions:
  - Checkout (make payment)
  - Admin refund
  - Status tracking

## 🧱 Current Project Structure (Console App)

```
PaymentProcessingDemo/
│
├── Program.cs                         // Entry point with user input menu
├── Services/
│   └── PaymentService.cs              // Central logic for payments/refunds/status
│
├── Interfaces/                        // Abstract interfaces for factory & services
│   ├── IPaymentGatewayFactory.cs
│   ├── IPaymentProcessor.cs
│   ├── IRefundHandler.cs
│   └── IStatusChecker.cs
│
├── Stripe/                            // Stripe-specific implementation
│   ├── StripeFactory.cs
│   ├── StripePaymentProcessor.cs
│   ├── StripeRefundHandler.cs
│   └── StripeStatusChecker.cs
│
├── PayPal/                            // PayPal-specific implementation
│   └── ...
│
└── Square/                            // Square-specific implementation
    └── ...
```

## ✅ Learn

- How to use **Abstract Factory** to manage related service families
- How to write **extensible** and **loosely-coupled** code
- Separation of concerns: UI, service logic, factory logic
- How to refactor a console app into a **real web API** structure

## 🔮 Future Roadmap – Web API Ready

This project is designed with a clean path to being **extended into a Web API**, with minimal refactoring.

### Future Enhancements (API-Level Architecture):

| Feature | Description |
|--------|-------------|
| 🛒 `POST /api/payments/checkout` | Trigger payment from customer |
| 💸 `POST /api/payments/refund` | Refund by admin |
| 🔍 `GET /api/payments/status/{transactionId}` | Check status by customer or admin |
| 🔐 Role-based access | Separate customer/admin authorization |
| 🗂️ Database Integration | Store transactions, track status |
| 🔔 Webhook Listeners | Real-time updates from gateways |
| 📊 Admin Dashboard | Transaction reports, search, filters |

## 🧠 Design Principles Used

- ✅ **SOLID Principles**
- ✅ **Single Responsibility**: Each class handles one purpose
- ✅ **Open/Closed Principle**: Easily add new gateways without changing existing logic
- ✅ **Separation of Concerns**: Console UI vs. payment logic vs. gateway details
- ✅ **Dependency Inversion**: High-level logic depends on abstractions

## 🏁 Running the Console App

1. Clone the repo or copy project files
2. Open in Visual Studio or VS Code
3. Build & run the project
4. Choose gateway → perform operations via menu (payment, refund, status)

## 💬 Example Usage

```
Select Gateway: 1. Stripe
Choose Action: 1. Make Payment
Enter Amount: 100.00
[Stripe] Processing payment of $100.00
```
[ApiController]
[Route("api/payments")]
public class PaymentController : ControllerBase
{
    private readonly PaymentService _service;
    public PaymentController(IPaymentGatewayFactory factory)
    {
        _service = new PaymentService(factory);
    }
    [HttpPost("checkout")]
    public IActionResult Checkout([FromBody] PaymentRequest request)
    {
        _service.MakePayment(request.Amount);
        return Ok("Payment processed.");
    }
    [HttpPost("refund")]
    public IActionResult Refund([FromBody] RefundRequest request)
    {
        _service.RefundPayment(request.TransactionId);
        return Ok("Refund processed.");
    }
    [HttpGet("status/{transactionId}")]
    public IActionResult Status(string transactionId)
    {
        _service.GetPaymentStatus(transactionId);
        return Ok("Status checked.");
    }
}


## 📌 Credits

This project was developed as a **hands-on exploration of design patterns** in a real-world context. Built to support clean transition from console-based learning to full API-based architecture.
