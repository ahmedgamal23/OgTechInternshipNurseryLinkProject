import 'package:flutter/material.dart';

class MealLog {
  final String studentName;
  final String mealType;
  final String status;
  final DateTime timestamp;

  MealLog({
    required this.studentName,
    required this.mealType,
    required this.status,
    required this.timestamp,
  });
}

class MealLogScreen extends StatefulWidget {
  @override
  _MealLogScreenState createState() => _MealLogScreenState();
}

class _MealLogScreenState extends State<MealLogScreen> {
  final List<String> students = ['Ahmed Khaled', 'Sara Mahmoud', 'Youssef Ali'];
  final List<String> mealTypes = ['Breakfast', 'Lunch', 'Snack'];
  final List<String> statuses = ['Ate All', 'Ate Some', 'Refused'];

  String? selectedStudent;
  String? selectedMealType;
  String? selectedStatus;

  List<MealLog> mealLogs = [];

  void addMealLog() {
    if (selectedStudent != null &&
        selectedMealType != null &&
        selectedStatus != null) {
      final newLog = MealLog(
        studentName: selectedStudent!,
        mealType: selectedMealType!,
        status: selectedStatus!,
        timestamp: DateTime.now(),
      );

      setState(() {
        mealLogs.add(newLog);
        selectedMealType = null;
        selectedStatus = null;
      });
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Daily Meals Log'),
        backgroundColor: Colors.blue,
        actions: [
          IconButton(onPressed: () {}, icon: Icon(Icons.notifications)),
        ],
        leading: IconButton(onPressed: () {}, icon: Icon(Icons.menu)),
      ),
      body: Padding(
        padding: const EdgeInsets.all(20.0),
        child: Column(
          children: [
            DropdownButtonFormField<String>(
              value: selectedStudent,
              decoration: InputDecoration(labelText: 'Select Student'),
              items: students.map((name) {
                return DropdownMenuItem(value: name, child: Text(name));
              }).toList(),
              onChanged: (value) {
                setState(() => selectedStudent = value);
              },
            ),
            SizedBox(height: 10),
            DropdownButtonFormField<String>(
              value: selectedMealType,
              decoration: InputDecoration(labelText: 'Select Meal Type'),
              items: mealTypes.map((meal) {
                return DropdownMenuItem(value: meal, child: Text(meal));
              }).toList(),
              onChanged: (value) {
                setState(() => selectedMealType = value);
              },
            ),
            SizedBox(height: 10),
            DropdownButtonFormField<String>(
              value: selectedStatus,
              decoration: InputDecoration(labelText: 'Select Meal Status'),
              items: statuses.map((status) {
                return DropdownMenuItem(value: status, child: Text(status));
              }).toList(),
              onChanged: (value) {
                setState(() => selectedStatus = value);
              },
            ),
            SizedBox(height: 15),
            ElevatedButton(
              onPressed: addMealLog,
              child: Text('Log Meal'),
              style: ElevatedButton.styleFrom(backgroundColor: Colors.blue),
            ),
            SizedBox(height: 20),
            Expanded(
              child: ListView.builder(
                itemCount: mealLogs.length,
                itemBuilder: (context, index) {
                  final log = mealLogs[index];
                  return Card(
                    elevation: 3,
                    child: ListTile(
                      title: Text('${log.studentName} - ${log.mealType}'),
                      subtitle: Text('${log.status} • ${log.timestamp}'),
                    ),
                  );
                },
              ),
            )
          ],
        ),
      ),
    );
  }
}
