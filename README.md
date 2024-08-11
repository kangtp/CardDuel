
<h2> 🃏 전략 카드 게임 : Card Duel 🃏</h2>
Card Duel은 매 라운드마다 카드를 3장 선택해 덱을 꾸리고 그 덱으로 적과 대결을 벌이는 턴제 전략 카드 게임입니다!    

<br/>
<br/>

<img src="https://github.com/user-attachments/assets/5d482a52-f9b3-488e-801a-adb8e191c143"  width="600" height="300"/>    

### ▶️[게임 트레일러](https://youtu.be/zk93o7YMGdA)

## 목차
  - [개요](#개요) 
  - [게임 설명](#게임-설명)
  - [주요 기능](#주요-기능)

## 개요
- **프로젝트 이름**: Card Duel ⚔️
- **개발 기간**: 2023.07
- **사용 기술 스택, 언어**: Unity, C#
- **팀 구성**: 개인 프로젝트

## 게임 설명
- 플레이어는 카드 3장을 선택하여 상대와 전투를 진행합니다. 카드는 공격카드, 이동카드가 있으며 공격카드는 숫자가 적혀있고 해당하는 숫자 칸에 있는 적을 공격합니다. 이동카드는 선택한 방향으로 한칸 이동합니다.    
선택한 카드를 한장씩 적과 번갈아가며 실행합니다.


|<img src="https://github.com/user-attachments/assets/87fb9945-6b41-4254-a0b9-3a3a94977ace"  width="600" height="200"/>|<img src="https://github.com/user-attachments/assets/33be8ba2-5a39-4c38-bbf8-70e744dcdc01"  width="600" height="200"/>|<img src="https://github.com/user-attachments/assets/59c9dcf7-d936-4f11-bb3c-84a7cc7d0102" width="600" height="200"/>|
|:------:|:---:|:---:|
|카드 선택|이동|공격|
<br/>

|<img src="https://github.com/user-attachments/assets/6cb08cf0-dfdb-42d4-8f7e-5281fa5fa30f"  width="400" height="200"/>|<img src="https://github.com/user-attachments/assets/7ee2848b-dfdb-4d68-83c5-dc0da4809b5f"  width="400" height="200"/>|
|:------:|:---:|
|12번 자리 공격|공격에 맞은 적 Hp 감소|

- 상대방의 체력을 모두 깎거나 자신의 체력이 모두 깎이면 Game Over입니다.
- 상대방의 공격은 피하고 내 공격은 적중시켜 전투에서 승리하세요!
<br/>

## 주요 기능

### 1. 적 AI 구현
- 적은 플레이어의 현재 위치를 받아와 플레이어의 위치를 포함해 그 주변을 공격하는 카드를 2장 선택합니다.
- 1장은 이동카드를 랜덤으로 선택합니다.
- 그 다음 뽑은 3장의 순서를 랜덤으로 섞어 덱을 빌딩합니다.


### 2. Render Texture를 사용해 미니맵 구현
- 플레이어와 적의 현재 위치를 나타내는 미니맵을 Render Texture에 출력하여 카드를 선택하는 UI에서 확인할 수 있게 했습니다.
<img src="https://github.com/user-attachments/assets/03f900b6-e0c6-4b36-9bbf-1f625d9907c6"  width="400" height="200"/>


<br/>

### 3. Coroutine을 사용해 턴제 시스템 구현
- 플레이어와 적이 돌아가면서 카드 한 장씩 발동하도록 coroutine을 사용하여 PlayerTurn()이 끝나면 EnemyTurn()을 호출하는 코드를 3번 반복하여 구현하였습니다.
