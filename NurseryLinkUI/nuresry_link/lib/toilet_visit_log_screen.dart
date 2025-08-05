import 'package:flutter/material.dart';

// Dummy student list (can be replaced with real student data)
final List<String> studentNames = ['Ahmed Khaled', 'Sara Mahmoud', 'Youssef Ali'];

class ToiletVisitLogScreen extends StatefulWidget {
  @override
  _ToiletVisitLogScreenState createState() => _ToiletVisitLogScreenState();
}

class _ToiletVisitLogScreenState extends State<ToiletVisitLogScreen> {
  String? selectedStudent;
  String? selectedVisitType;
  final TextEditingController commentsController = TextEditingController();

  void logVisit() {
    if (selectedStudent != null && selectedVisitType != null) {
      final timestamp = DateTime.now();
      // You can replace this with saving to DB or API
      print('Student: $selectedStudent');
      print('Visit Type: $selectedVisitType');
      print('Comments: ${commentsController.text}');
      print('Timestamp: $timestamp');

      ScaffoldMessenger.of(context).showSnackBar(
        SnackBar(content: Text('Toilet visit logged successfully!')),
      );

      // Reset fields
      setState(() {
        selectedStudent = null;
        selectedVisitType = null;
        commentsController.clear();
      });
    } else {
      ScaffoldMessenger.of(context).showSnackBar(
        SnackBar(content: Text('Please select student and visit type')),
      );
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Toilet Visit Log'),
        backgroundColor: Colors.blue,
      ),
      body: Padding(
        padding: const EdgeInsets.all(20.0),
        child: Column(
          children: [
            DropdownButtonFormField<String>(
              value: selectedStudent,
              hint: Text('Select Student'),
              items: studentNames.map((name) {
                return DropdownMenuItem(
                  value: name,
                  child: Text(name),
                );
              }).toList(),
              onChanged: (value) {
                setState(() {
                  selectedStudent = value;
                });
              },
              decoration: InputDecoration(
                border: OutlineInputBorder(),
              ),
            ),
            SizedBox(height: 20),
            DropdownButtonFormField<String>(
              value: selectedVisitType,
              hint: Text('Select Visit Type'),
              items: ['Pee', 'Poo'].map((type) {
                return DropdownMenuItem(
                  value: type,
                  child: Text(type),
                );
              }).toList(),
              onChanged: (value) {
                setState(() {
                  selectedVisitType = value;
                });
              },
              decoration: InputDecoration(
                border: OutlineInputBorder(),
              ),
            ),
            SizedBox(height: 20),
            TextField(
              controller: commentsController,
              decoration: InputDecoration(
                labelText: 'Comments (optional)',
                border: OutlineInputBorder(),
              ),
              maxLines: 2,
            ),
            SizedBox(height: 30),
            ElevatedButton.icon(
              onPressed: logVisit,
              icon: Icon(Icons.check),
              label: Text('Log Visit'),
              style: ElevatedButton.styleFrom(
                backgroundColor: Colors.blue,
                padding: EdgeInsets.symmetric(horizontal: 40, vertical: 15),
              ),
            ),
          ],
        ),
      ),
    );
  }
}
