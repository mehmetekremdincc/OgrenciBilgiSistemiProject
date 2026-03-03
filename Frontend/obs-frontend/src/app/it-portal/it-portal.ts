import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-it-portal',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './it-portal.html',
  styleUrls: ['./it-portal.scss']  // <-- düzeltilmiş
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

  // Seçili öğeler
  selectedDept: any = null;
  selectedTeacher: any = null;
  selectedCourse: any = null;

  // Form inputları
  newDeptName = '';
  newTeacherName = '';
  newCourse = { code: '', name: '' };

  // Navigasyon Fonksiyonları
  selectDept(dept: any) {
    this.selectedDept = dept;
    this.selectedTeacher = null;
    this.selectedCourse = null;
  }

  selectTeacher(t: any) {
    this.selectedTeacher = t;
    this.selectedCourse = null;
  }

  selectCourse(c: any) {
    this.selectedCourse = c;
  }

  // Bölüm Ekle
  addDepartment() {
    if (!this.newDeptName) return;
    this.universityData.push({ deptName: this.newDeptName, teachers: [] });
    this.newDeptName = '';
  }

  // Bölüm Sil
  deleteDept(dept: any, event: Event) {
    event.stopPropagation();
    this.universityData = this.universityData.filter(d => d !== dept);
    if (this.selectedDept === dept) this.selectedDept = null;
  }

  // Hoca Ekle
  addTeacherToDept() {
    if (!this.newTeacherName || !this.selectedDept) return;
    this.selectedDept.teachers.push({ name: this.newTeacherName, courses: [] });
    this.newTeacherName = '';
  }

  // Hoca Sil
  deleteTeacher(teacher: any, event: Event) {
    event.stopPropagation();

    if (!this.selectedDept || !Array.isArray(this.selectedDept.teachers)) return;
    const index = this.selectedDept.teachers.findIndex((t: any) => t === teacher);
    if (index > -1) {
      this.selectedDept.teachers.splice(index, 1);
      if (this.selectedTeacher === teacher) {
        this.selectedTeacher = null;
        this.selectedCourse = null; 
      }
    }
  }
  

  // Ders Atama
  assignCourseToTeacher() {
    if (!this.newCourse.code || !this.newCourse.name || !this.selectedTeacher) return;
    this.selectedTeacher.courses.push({ ...this.newCourse, students: [] });
    this.newCourse = { code: '', name: '' };
  }

  // Öğrenci Atama
  assignStudent() {
    const name = prompt("Derse eklenecek öğrenci adı:");
    if (name && this.selectedCourse) {
      this.selectedCourse.students.push({ id: Math.floor(Math.random() * 1000), name, midterm: 0, final: 0 });
    }
  }

  // Not Güncelle (Bilgi İşlem Yetkisi)
  updateGrade() {
    alert("Bilgi İşlem Yetkisiyle Notlar Güncellendi!");
  }
}
