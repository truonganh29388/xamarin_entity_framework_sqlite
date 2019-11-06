using Firebase;
using Firebase.Auth;
using Java.Util.Concurrent;
using System;
using TaskManager.Services;

namespace TaskManager.Droid.Services
{
    public class OtpService : IOtpService
    {
        public bool SendOtp(string phoneNumber)
        {
            var phoneAuthCallbacks = new PhoneAuthCallbacks();
            try
            {
                PhoneAuthProvider.Instance.VerifyPhoneNumber(phoneNumber, 60, TimeUnit.Seconds, MainActivity.CurrentActivityRef, phoneAuthCallbacks);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            // You can now obtain a user credential via the verification code and verification ID and 
            return true;
        }
    }

     public class PhoneAuthCallbacks : PhoneAuthProvider.OnVerificationStateChangedCallbacks
    {
        public override void OnVerificationCompleted(PhoneAuthCredential credential)
        {
            var cre = credential;
            // This callback will be invoked in two situations:
            // 1 - Instant verification. In some cases the phone number can be instantly
            //     verified without needing to send or enter a verification code.
            // 2 - Auto-retrieval. On some devices Google Play services can automatically
            //     detect the incoming verification SMS and perform verification without
            //     user action.         
        }

        public override void OnCodeSent(string verificationId, PhoneAuthProvider.ForceResendingToken forceResendingToken)
        {
            // The SMS verification code has been sent to the provided phone number, we
            // now need to ask the user to enter the code and then construct a credential
            // by combining the code with a verification ID.
            base.OnCodeSent(verificationId, forceResendingToken);
        }

        public override void OnVerificationFailed(FirebaseException exception)
        {
            var ex = exception;
        }
    }
}