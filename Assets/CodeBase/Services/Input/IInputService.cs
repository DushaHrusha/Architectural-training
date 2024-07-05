using Architectural_training.Assets.CodeBase.Infrastructure.Services;
using UnityEngine;

namespace CodeBase.Services.Input
{
  public interface IInputService : ISercies
  {
    Vector2 Axis { get; }

    bool IsAttackButtonUp();
  }
}