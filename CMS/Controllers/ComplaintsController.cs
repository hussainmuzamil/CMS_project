using System;
using System.Collections.Generic;
using AutoMapper;
using CMS.Data;
using CMS.Dtos;
using CMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Controllers
{
    //API Endpoints
    [Route("api/complaints")]
    [ApiController]
    public class ComplaintsController : ControllerBase
    {
        private readonly ICMSRepo _repository;
        private readonly IMapper _mapper;

        public ComplaintsController(ICMSRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }

        //Get api/complaints
        [HttpGet]
        public ActionResult<IEnumerable<ComplaintReadDto>> GetAllComplaints()
        {
            var complaintItems = _repository.GetAllComplaints();
            return Ok(_mapper.Map<IEnumerable<ComplaintReadDto>>(complaintItems));

        }

        //Get api/complaints/{dept}/dept
        [HttpGet("{dept}/dept", Name = "GetComplaintByDept")]
        public ActionResult<IEnumerable<ComplaintReadDto>> GetComplaintByDept(string dept)
        {
            var complaintItems = _repository.GetComplaintByDept(dept);
            return Ok(_mapper.Map<IEnumerable<ComplaintReadDto>>(complaintItems));

        }

        //Get api/complaints/{uid}/uid
        [HttpGet("{uid}/uid", Name = "GetComplaintByUserID")]
        public ActionResult<IEnumerable<ComplaintReadDto>> GetComplaintByUserID(string uid)
        {
            var complaintItems = _repository.GetComplaintByUserID(uid);
            return Ok(_mapper.Map<IEnumerable<ComplaintReadDto>>(complaintItems));

        }






        //GET api/complaints/{id}
        [HttpGet("{id}", Name = "GetComplaintById")]
        public ActionResult<ComplaintReadDto> GetComplaintByID(int id)
        {
            var complainItem = _repository.GetComplaintByID(id);
            if (complainItem != null)
            {
                return Ok(_mapper.Map<ComplaintReadDto>(complainItem));
            }
            else
            {
                return NotFound();
            }

        }

        //POST api/complaints
        [HttpPost]
        public ActionResult<ComplaintReadDto> CreateComplaint(ComplaintCreateDto complainCreateDto)
        {
            var complaintModel = _mapper.Map<Complaint>(complainCreateDto);
            _repository.CreateComplaint(complaintModel);
            _repository.SaveChanges();

            var complainReadDto = _mapper.Map<ComplaintReadDto>(complaintModel);

            return CreatedAtRoute(nameof(GetComplaintByID), new { Id = complainReadDto.complaintID }, complainReadDto);


        }

        //PUT api/complaints/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateComplaint(int id,ComplaintUpdateDto complaintUpdateDto)
        {
            var complainModelFromRepo = _repository.GetComplaintByID(id);
            if(complainModelFromRepo == null)
            {
                return NotFound();

            }

            _mapper.Map(complaintUpdateDto, complainModelFromRepo);

            _repository.UpdateComplaint(complainModelFromRepo);

            _repository.SaveChanges();

            return NoContent();

        }

        //PATCH api/complaints/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialComplaintUpdate(int id,JsonPatchDocument<ComplaintUpdateDto> patchDoc)
        {
            var complainModelFromRepo = _repository.GetComplaintByID(id);
            if (complainModelFromRepo == null)
            {
                return NotFound();

            }
            var complainToPatch = _mapper.Map<ComplaintUpdateDto>(complainModelFromRepo);
            patchDoc.ApplyTo(complainToPatch, ModelState);

            if (!TryValidateModel(complainToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(complainToPatch, complainModelFromRepo);

            _repository.UpdateComplaint(complainModelFromRepo);

            _repository.SaveChanges();

            return NoContent();


        }

        //DELETE api/complaints/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteComplain(int id)
        {
            var complaintModelFromRepo = _repository.GetComplaintByID(id);
            if (complaintModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteComplaint(complaintModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }






    }
}
