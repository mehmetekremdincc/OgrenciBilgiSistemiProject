import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-it-portal',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './it-portal.html',
  styleUrl: './it-portal.scss'
})
export class ItPortalComponent {
  // ANA VERİ DEPOSU (DATABASE GİBİ DÜŞÜN)
  universityData = [
    {
      deptName: 'Yazılım Mühendisliği',
      teachers: [
        {
          name: 'Dr. Ahmet Yılmaz',
          courses: [
            {
              code: 'YAZ101', name: 'Algoritma',
              students: [
                { id: 202101, name: 'Ekrem Dinç', midterm: 70, final: 80 },
                { id: 202102, name: 'Zehra Yolcu', midterm: 40, final: 50 }
              ]
            },
            { code: 'YAZ202', name: 'Web Programlama', students: [] }
          ]
        }
      ]
    },
    {
      deptName: 'Bilgisayar Mühendisliği',
      teachers: [
        { name: 'Prof. Canan Dağ', courses: [{ code: 'BIL101', name: 'Donanım', students: [] }] }
      ]
    }
  ];

  selectedDept: any = null;
  selectedTeacher: any = null;
  selectedCourse: any = null;

  // Navigasyon Fonksiyonları
  selectDept(dept: any) { this.selectedDept = dept; this.selectedTeacher = null; this.selectedCourse = null; }
  selectTeacher(t: any) { this.selectedTeacher = t; this.selectedCourse = null; }
  selectCourse(c: any) { this.selectedCourse = c; }

  // Bilgi İşlem Yetkisi: Not Değiştirme
  updateGrade() {
    alert("Bilgi İşlem Yetkisiyle Notlar Güncellendi!");
  }

  // Yeni Öğrenci Atama
  assignStudent() {
    const name = prompt("Derse eklenecek öğrenci adı:");
    if (name && this.selectedCourse) {
      this.selectedCourse.students.push({ id: Math.floor(Math.random() * 1000), name: name, midterm: 0, final: 0 });
    }
  }
}
