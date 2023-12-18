using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLockedDoor
{
    internal class Door
    {
        public int _passcode;
        public DoorState State { get; private set; }

        public Door(int passcode)
        {
            State = DoorState.Locked;
            _passcode = passcode;
        }

        public void ChangePasscode(int existingCode, int newCode)
        {
            if (existingCode == _passcode) _passcode = newCode;
        }

        public void LockDoor()
        {
            if (State == DoorState.Closed) State = DoorState.Locked;
        }

        public void UnlockDoor(int passcode)
        {
            if (State == DoorState.Locked && passcode == _passcode) State = DoorState.Closed;
        }

        public void CloseDoor()
        {
            if (State == DoorState.Open) State = DoorState.Closed;
        }

        public void OpenDoor()
        {
            if (State == DoorState.Closed) State = DoorState.Open;
        }
    }
}
