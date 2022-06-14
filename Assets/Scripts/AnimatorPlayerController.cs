using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorPlayerController : MonoBehaviour
{
    public static class Params
    {
        public const string Speed = "Speed";
    }

    public static class States
    {
        public const int Idle = 0;
        public const int Run = 1;
    }
}
