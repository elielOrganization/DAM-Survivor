Estructura del proyecto

Assets/
│
├── _Project/
│   │
│   ├── Scripts/
│   │   │
│   │   ├── Player/
│   │   │   ├── PlayerController.cs
│   │   │   ├── PlayerHealth.cs
│   │   │   ├── PlayerLevelSystem.cs          ← Subida de nivel
│   │   │   └── PlayerDebugInput.cs           ← Comandos debug (Block B)
│   │   │
│   │   ├── Weapons/                          ← BLOQUE A + BLOQUE B
│   │   │   ├── _Base/
│   │   │   │   ├── WeaponBase.cs
│   │   │   │   ├── ProjectileBase.cs
│   │   │   │   ├── WeaponStats.cs            ← Level, daño, cooldown
│   │   │   │   └── Damageable.cs
│   │   │   │
│   │   │   ├── FrostZone/
│   │   │   │   ├── FrostZoneController.cs
│   │   │   │   ├── FrostZoneStats.cs
│   │   │   │   └── FrostZoneLevelUp.cs
│   │   │   │
│   │   │   ├── EscudoOrbital/
│   │   │   │   ├── OrbitalShieldController.cs
│   │   │   │   ├── OrbitalShieldOrb.cs
│   │   │   │   └── OrbitalShieldLevelUp.cs
│   │   │   │
│   │   │   ├── VaritaMagica/
│   │   │   │   ├── MagicWandController.cs
│   │   │   │   ├── MagicMissile.cs
│   │   │   │   └── MagicWandLevelUp.cs
│   │   │   │
│   │   │   └── WeaponManager.cs              ← Inventario + obtención de armas
│   │   │
│   │   ├── Enemies/
│   │   │   ├── EnemyBase.cs
│   │   │   ├── EnemyZangano.cs               ← Enemigo 1
│   │   │   ├── EnemyCorredor.cs              ← Enemigo 2
│   │   │   ├── EnemyTanque.cs                ← Enemigo 3
│   │   │   ├── EnemyEnjambre.cs              ← Enemigo 4
│   │   │   ├── EnemySpawner.cs
│   │   │   ├── WaveSystem.cs                 ← TODA la tabla de oleadas
│   │   │   ├── EnemyLootDrop.cs              ← Botín variado
│   │   │   └── EnemyFeedback.cs              ← Feedback de daño visual
│   │   │
│   │   ├── UI/
│   │   │   ├── PauseMenu.cs
│   │   │   ├── TitleScreenController.cs
│   │   │   └── LevelUpPanelController.cs     ← Elección del superviviente (B9)
│   │   │
│   │   └── Game/
│   │       ├── GameManager.cs
│   │       └── CameraShake.cs                ← Bloque C (camera shake)
│   │
│   ├── Prefabs/
│   │   ├── Player/
│   │   ├── Weapons/
│   │   ├── Projectiles/
│   │   ├── Enemies/
│   │   ├── Orbs/           ← Verde/Azul/Dorado
│   │   ├── VFX/
│   │   └── UI/
│   │
│   ├── Scenes/
│   │   ├── MainMenu.unity
│   │   └── Game.unity
│   │
│   ├── Materials/
│   ├── Animations/
│   ├── Audio/
│   ├── Sprites/
│   └── Fonts/
│
├── Packages/
├── ProjectSettings/
└── .gitignore
