import 'package:flutter/material.dart';
import 'meal_log_screen.dart'; // Make sure this file exists and is implemented

// Class model
class ClassGroup {
  final String className;

  ClassGroup({required this.className});
}

// Student model
class Student {
  final String studentCode;
  final String fullName;
  final DateTime dateOfBirth;
  final ClassGroup classGroup;

  Student({
    required this.studentCode,
    required this.fullName,
    required this.dateOfBirth,
    required this.classGroup,
  });
}

// Sample data: Students assigned to the teacher's class
final List<Student> teacherStudents = [
  Student(
    studentCode: 'STU001',
    fullName: 'Ahmed Khaled',
    dateOfBirth: DateTime(2018, 4, 21),
    classGroup: ClassGroup(className: 'Blue Butterflies'),
  ),
  Student(
    studentCode: 'STU002',
    fullName: 'Sara Mahmoud',
    dateOfBirth: DateTime(2019, 7, 10),
    classGroup: ClassGroup(className: 'Blue Butterflies'),
  ),
  Student(
    studentCode: 'STU003',
    fullName: 'Youssef Ali',
    dateOfBirth: DateTime(2017, 9, 5),
    classGroup: ClassGroup(className: 'Blue Butterflies'),
  ),
];

class TeacherHomeScreen extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        backgroundColor: Colors.blue,
        actions: [
          IconButton(
            icon: Icon(Icons.notifications),
            onPressed: () {
              // Handle notifications
            },
          ),
        ],
        leading: IconButton(
          icon: Icon(Icons.menu),
          onPressed: () {
            // Handle drawer/menu
          },
        ),
        elevation: 0,
      ),
      body: Padding(
        padding: const EdgeInsets.all(20.0),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Text(
              'My Students',
              style: TextStyle(
                fontSize: 26,
                fontWeight: FontWeight.bold,
              ),
            ),
            SizedBox(height: 20),
            Expanded(
              child: ListView.builder(
                itemCount: teacherStudents.length,
                itemBuilder: (context, index) {
                  final student = teacherStudents[index];
                  return Card(
                    elevation: 2,
                    margin: EdgeInsets.symmetric(vertical: 8),
                    child: ListTile(
                      leading: CircleAvatar(
                        backgroundColor: Colors.blue,
                        child: Text(
                          student.fullName[0],
                          style: TextStyle(color: Colors.white),
                        ),
                      ),
                      title: Text(student.fullName),
                      subtitle: Text(
                        'Class: ${student.classGroup.className}\nDOB: ${student.dateOfBirth.day}/${student.dateOfBirth.month}/${student.dateOfBirth.year}',
                      ),
                    ),
                  );
                },
              ),
            ),
          ],
        ),
      ),
      floatingActionButton: FloatingActionButton.extended(
        onPressed: () {
          Navigator.push(
            context,
            MaterialPageRoute(builder: (context) => MealLogScreen()),
          );
        },
        label: Text('Log Meals'),
        icon: Icon(Icons.fastfood),
        backgroundColor: Colors.blue,
      ),
    );
  }
}
