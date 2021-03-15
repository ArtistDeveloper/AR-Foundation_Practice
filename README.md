AR Foundation Test / gitignore 작동 테스트

프로젝트 클론 하면 빌드세팅 했던 것이 사라져있음
## Build Settings
-> other settings
1. API레벨 24이상으로 맞추기
2. Graphics API -> Vulkan APi 삭제

## 주의점
1. 프리팹, 오브젝트 위치가 (0,0)이 아니면 Instantiate 함수를 사용해서 객체를 생성했을 때, 지정된 좌표에서 어긋나게 객체가 생성된다.
