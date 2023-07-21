function addStudent() {
    students = getStudents();
    const student = {
      id: document.getElementById("id").value,
      firstName: document.getElementById("firstName").value,
      lastName: document.getElementById("lastName").value,
      studyArea: document.getElementById("studyArea").value
    };

    if(student.id != '' && student.firstName != '' && student.lastname != '' && student.studyArea != ''){
        students.push(student);

        setStudentsToLocalStorage(students);

        alert('Student has been added to Local Storage!');
    }
}


function getStudents(){

    const studentsJSON = localStorage.getItem('students');
    const students = studentsJSON ? JSON.parse(studentsJSON) : [];

    return students;
}

function getStudent(id){
  const students = getStudents();
  const student = students.filter((s) => s.id == id);
  return student[0];
}

function deleteStudent(id){
  students = getStudents();

  students = students.filter((student) => student.id != id);
  
  setStudentsToLocalStorage(students);
  populateTable();
}


function editStudent(id){
  student = getStudent(id);
  localStorage.setItem('editStudentData', JSON.stringify(student));
}


function submitEditStudent(id) {
  const editedStudent = {
    id: id,
    firstName: document.getElementById("firstName").value,
    lastName: document.getElementById("lastName").value,
    studyArea: document.getElementById("studyArea").value
  };

  const students = getStudents();
  const editedStudentIndex = students.findIndex((student) => student.id === id);

  if (editedStudentIndex !== -1) {
    students[editedStudentIndex] = editedStudent;
    setStudentsToLocalStorage(students);
    alert('Student information has been updated!');
  }
  window.location.href = 'C:\\Users\\marin\\source\\repos\\Mono-practice\\Students\\index.html';

}

function populateEditedStudent(){

  const studentEditForm = document.getElementById('studentEditForm');
  studentEditForm.addEventListener('submit', (event) => {
    event.preventDefault();
    const student= JSON.parse(localStorage.getItem('editStudentData'));
    submitEditStudent(student.id);
  })

  editedStudent = JSON.parse(localStorage.getItem('editStudentData'));
  document.getElementById("firstName").value = editedStudent.firstName;
  document.getElementById("lastName").value = editedStudent.lastName;
  document.getElementById("studyArea").value = editedStudent.studyArea;
}

function populateTable() {
  const tbody = document.querySelector('#myTable tbody');
  tbody.innerHTML = ''; 
  students = getStudents();
  students.forEach((student) => {
    const row = document.createElement('tr');
    const idCell = document.createElement('td');
    const firstNameCell = document.createElement('td');
    const lastNameCell = document.createElement('td');
    const studyAreaCell = document.createElement('td');
    const deleteCell = document.createElement('td');
    const editCell = document.createElement('td');

    idCell.textContent = student.id;
    firstNameCell.textContent = student.firstName;
    lastNameCell.textContent = student.lastName;
    studyAreaCell.textContent = student.studyArea;


    const deleteButton = document.createElement('button');
    deleteButton.innerHTML = '<i class="fa-solid fa-trash"></i>';
    deleteButton.addEventListener('click', () => deleteStudent(student.id));
    deleteCell.appendChild(deleteButton);

    const editButton = document.createElement('button');
    const editLink = document.createElement('a');
    editLink.href = "C:\\Users\\marin\\source\\repos\\Mono-practice\\Students\\Pages\\editStudent.html";
    editButton.innerHTML = '<i class="fa-solid fa-pen-to-square"></i>';
    editButton.addEventListener('click', () => editStudent(student.id));
    editLink.appendChild(editButton);
    editCell.appendChild(editLink);

    row.appendChild(idCell);
    row.appendChild(firstNameCell);
    row.appendChild(lastNameCell);
    row.appendChild(studyAreaCell);
    row.appendChild(deleteCell);
    row.appendChild(editCell);
    tbody.appendChild(row);
  });
}

  function setStudentsToLocalStorage(students){
    localStorage.setItem('students', JSON.stringify(students));
}

