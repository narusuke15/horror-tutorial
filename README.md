# horror-tutorial

Project สอนใช้ Unity ทำเกมผี

### Unity Version: 2020.3.27f1

---

## สรุปเนื้อหาแต่ละ part

### Part 1: Scene Setup
- ทดสอบการใช้งาน `Asset Store` และ `Package Manager` เพื่อช่วยในการทำเกม
- ลองใช้งาน `FPS Controller`
- สร้าง prototype ฉาก ด้วย `ProBuilder`
- ลองจัดแสงเงาเกมผีเบื้องต้นและวิธีการทำให้ฉากมืด

### Part 2: Basic Lighting and Particles
- อธิบายการใช้งาน `Probuilder` เพิ่มเติม
- ทำ scripts คุมไฟฉายเปิด/ปิดแบบง่าย
- ศึกษาการทำงานของ `Materials`
- ลองใส่ `SkyBox`
- ทดลองการใช้งาน `Particle Effect` เบื้องต้นผ่านการทำ หมอก และ ไฟคบเพลิง

### Part 3: Door Interaction
- ลองใส่ `prop` ที่เคลื่อนที่ได้และไม่ได้
- สร้าง fade-in overlay
- ลองใช้ `Animator` สร้าง Animation เปิดปิดประตู
- วิธีการใช้งาน `Unity UI` เบื้องต้น
- เขียนการ interaction กับประตูผ่าน `Raycast`

### Part 4: Flashlight
- เพิ่มระบบการใช้ไฟฉาย
- เพิ่มระบบแบตเตอรี่
- ระบบแสดง HUD
- ระบบเก็บแบตเตอรี่และหัดเขียน `interface`

### Part 5: Rendering
- ปรับ rendering path จาก built-in เป็น `URP`
- ใช้ `light baking` ทำให้แสงสวยและลื่น
- ใช้ `light probe` ใส่แสง bake ให้วัตถุ dynamic
- เปิด `Occlusion culling` เพื่อปิด object ที่ไม่ได้อยู่ในกล้อง

### Part 6: Sound and Event trigger
- เสียง `Ambient`
- ใส่เสียง `Foot step`
- ทำ `event trigger` Jumpscare
- ทำ cutscene ด้วย `timeline`