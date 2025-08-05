import 'package:flutter/material.dart';

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

// Sample data (Only the parent's children)
final List<Student> parentStudents = [
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
    classGroup: ClassGroup(className: 'Sunshine Group'),
  ),
];

class ParentHomeScreen extends StatelessWidget {
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
              'Your Children',
              style: TextStyle(
                fontSize: 26,
                fontWeight: FontWeight.bold,
              ),
            ),
            SizedBox(height: 20),
            Expanded(
              child: ListView.builder(
                itemCount: parentStudents.length,
                itemBuilder: (context, index) {
                  final student = parentStudents[index];
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
    );
  }
}
