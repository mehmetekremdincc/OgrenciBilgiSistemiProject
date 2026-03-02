import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-admin',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './admin.html',
  styleUrl: './admin.scss'
})
export class AdminComponent {
  teacherName = "Dr. Ahmet Yılmaz";
  department = "Yazılım Mühendisliği";

  // Hocanın girdiği dersler ve içindeki öğrenci datası
  myCourses = [
    {
      id: 1,
      name: "Algoritma ve Programlama",
      classes: [
        {
          level: 1, students: [
            { id: 202101, name: "Ali Veli", midterm: 50, final: 70 },
            { id: 202102, name: "Ayşe Fatma", midterm: 80, final: 90 }
          ]
        },
        { level: 2, students: [] }
      ]
    },
    {
      id: 2,
      name: "Veritabanı Yönetimi",
      classes: [
        {
          level: 3, students: [
            { id: 201905, name: "Mehmet Öz", midterm: 40, final: 30 }
          ]
        }
      ]
    }
  ];

  selectedCourse: any = null;
  selectedClass: any = null;

  // Ders seçildiğinde sınıfları sıfırla
  selectCourse(course: any) {
    this.selectedCourse = course;
    this.selectedClass = null;
  }

  selectClass(cls: any) {
    this.selectedClass = cls;
  }

  calculateAvg(m: number, f: number) {
    return (m * 0.4) + (f * 0.6);
  }
}
